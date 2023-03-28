using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Subscribe(string email)
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
    }
}
