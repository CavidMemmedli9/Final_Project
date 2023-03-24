using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser()
            {
                UserName = register.UserName,
                Email = register.Email,
                FullName = register.FullName
            };
            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }

            //await _userManager.AddToRoleAsync(user, RolesEnum.Member.ToString());

            return RedirectToAction("index", "home");
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "email ve yaxud parol sehvdir");
                return View(login);
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "hesab bloklanib");
                return View(login);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "email ve yaxud parol sehvdir");
                return View(login);
            }

            await _signInManager.SignInAsync(user, login.RememberMe);
           
            //{
            //    return Redirect(ReturnUrl);
            //}

            return RedirectToAction("login");
        }
    }
}
