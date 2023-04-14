using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ProfileVM profileVM = new ProfileVM();
            profileVM.Slider = _context.Slider.FirstOrDefault();
            profileVM.AboutProvider = _context.AboutProvider.FirstOrDefault();
            profileVM.News_Articles = _context.News_Articles.ToList();
            profileVM.Category = _context.Category.ToList();
            profileVM.Related_Provider = _context.Related_Provider.ToList();

            profileVM.Settings = _context.Settings.ToList();
            return View(profileVM);
        }

        [HttpPost]
        public IActionResult Quote( Quote quote)
        {
            _context.Quote.Add(quote);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
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
