using FinalProject.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Mail;
using System.Net;
using FinalProject.Models;

namespace FinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SubscribeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var email = _appDbContext.Subscribes.ToList();
            return View(email);
        }

        public IActionResult SendMail()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(string message)
        {
          List<Subscribe>subscribes = _appDbContext.Subscribes.ToList();
            foreach (Subscribe email in subscribes)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("javidsm@code.edu.az", "Job Finder");
                mailMessage.To.Add(new MailAddress(email.Email));


                mailMessage.Subject = "New Vacancy";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"{message}";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("javidsm@code.edu.az", "oahikyiysypxurxq");
                smtpClient.Send(mailMessage);
              
            }
            return RedirectToAction("Index");
        }


      
    }
}
