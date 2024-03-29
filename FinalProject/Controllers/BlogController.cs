﻿using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace FinalProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BlogController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ArticlesVM model = new();
            model.Categories = await _context.Category.ToListAsync();
            model.Articles = await _context.Articles.OrderByDescending(p=>p.Id).ToListAsync();
            model.JobInfo = await _context.JobInfo.OrderByDescending(p => p.Id).ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Search(string item)
        {
            List<Articles> blog = new();
            if (item != null && item.Length > 1)
            {
                blog = await _context.Articles.Where(c => c.Title.ToLower().Contains(item.ToLower())).ToListAsync();
            }
            return PartialView("_SearchPartial", blog);
        }

        public IActionResult Detail(int? id)
        {
            BlogDetailVM article = new BlogDetailVM();
            article.Categories = _context.Category.ToList();
            article.Articles = _context.Articles.Include(t => t.Blog).
                Include(c => c.Comments).
                ThenInclude(c => c.AppUser).
                FirstOrDefault(t => t.Id == id);
            article.JobInfo =  _context.JobInfo.OrderByDescending(p => p.Id).ToList();

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string text, int blogId)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Comment comment = new Comment()
            {
                AppUserId = user.Id,
                ArticlesId = blogId,
                Text = text
            };
            comment.CreatedTime= DateTime.Now;
            _context.Comment.Add(comment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Detail), new {id=blogId});
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Comment comment = _context.Comment.Find(id);
            _context.Comment.Remove(comment);
            comment.IsDeleted = true;
            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = comment.ArticlesId });
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
