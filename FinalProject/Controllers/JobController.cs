using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace FinalProject.Controllers
{
   
    public class JobController : Controller
    {
        private readonly AppDbContext _context;

        public JobController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? cityid,int? categoryid,int? maxprice)
        {
            var query = _context.JobInfo.Include(j=>j.Category).Include(x=>x.City).AsQueryable();
            JobVM jobVM = new JobVM();
            if (categoryid != null)
            {
                query = query.Where(j=>j.CategoryId == categoryid);
            }
            if (cityid != null)
            {
                query = query.Where(j => j.CityId == cityid);
            }
            if (maxprice != null)
            {
                query = query.Where(q => q.Price <= maxprice);
            }

            jobVM.JobInfo = query.ToList();
            jobVM.Background = _context.Background.FirstOrDefault();
           

            jobVM.City = _context.City.ToList();
            jobVM.Category = _context.Category.ToList();
            return View(jobVM);
        }

        public IActionResult JobDetail(int Id,int? cityid)
        {
            var data = _context.JobInfo.FirstOrDefault(p => p.Id == Id);
            if (data == null)
            {
                return RedirectToAction("Index", "job");
            }
            return View(data);
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