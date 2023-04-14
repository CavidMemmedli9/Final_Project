using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace FinalProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Subscribes(string email)
        {
            Subscribe data = new()
            {
                Email = email
            };
            await _context.Subscribes.AddAsync(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsVM contact)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Xeta meydana geldi");
            }
            Contact data = new() {
            EmailAddress = contact.EmailAddress,
            Name= contact.Name,
            Phone = contact.Phone,
            Subject = contact.Subject,
            Message = contact.Subject,
            };
            _context.Contact.Add(data);
            _context.SaveChanges();
            contact.Response = "Succesfuly sended!";
            return View(nameof(Index),contact);
        }

        public IActionResult Second()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            if (_context.IsRegisteredEmail(email))
            {
                TempData["Error"] = "Email is subscribed";
                return RedirectToAction("Index", "Home");
            };

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("javidsm@code.edu.az", "Job Finder");
            mailMessage.To.Add(new MailAddress(email));


            mailMessage.Subject = "Thanks Subscribe";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"Thanks Subscribe";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("javidsm@code.edu.az", "tvikjyuwqtlnlyty");
            smtpClient.Send(mailMessage);

            _context.SaveEmail(email);
            return RedirectToAction("Index", "Home");
        }
    }
}
