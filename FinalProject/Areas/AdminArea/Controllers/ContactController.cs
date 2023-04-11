using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var contact= _appDbContext.Contact.ToList();
            return View(contact);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = _appDbContext.Contact.Find(id);
            if (contact == null) return NotFound();

        

            _appDbContext.Contact.Remove(contact);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
