using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace FinalProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM();
            aboutVM.Slider = _context.Slider.FirstOrDefault();
            aboutVM.About = _context.About.FirstOrDefault();
            aboutVM.Statics = _context.Statics.FirstOrDefault();

            aboutVM.Background = _context.Background.FirstOrDefault();
            return View(aboutVM);
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
