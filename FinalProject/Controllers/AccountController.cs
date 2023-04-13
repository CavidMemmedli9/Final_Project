using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using FinalProject.Helpers;

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

            if (!ModelState.IsValid) return Content("Pleas enter required fields");
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

            await _userManager.AddToRoleAsync(user, RolesEnum.Moderator.ToString());

            return Content("1");
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return Content("Please enter required fields");

            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return Content("This account not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            
            if (result.IsLockedOut)
            {
                return Content("This account is blocked");
            }

            if (!result.Succeeded)
            {
                return Content("Email or password incorrect");
            }

            await _signInManager.SignInAsync(user, login.RememberMe);

            //{
            //    return Redirect(ReturnUrl);
            //}

            return Content("1");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(forgetPasswordVM.AppUser.Email);

            if (appUser == null)
            {
                ModelState.AddModelError("Error1", "Bele bir Email Yoxdur");
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            var link = Url.Action(nameof(ResetPassword), "Account", new
            {
                email = appUser.Email,
                token
            }, Request.Scheme, Request.Host.ToString());

            string url = Url.Action(nameof(ResetPassword), "Account"
                , new { email = appUser.Email, token }, Request.Scheme, Request.Host.ToString());

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("javidsm@code.edu.az", "subject");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = $"<a href='{url}'>Please Click here for Reset Password</a>";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("javidsm@code.edu.az", "tvikjyuwqtlnlyty");

            smtpClient.Send(mailMessage);
            return RedirectToAction("Index");
        }

        public IActionResult ResetPassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, ForgetPasswordVM forgetPassword, string token)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (!ModelState.IsValid) return View();

            await _userManager.ResetPasswordAsync(appUser, token, forgetPassword.Password);

            return RedirectToAction("login", "account");

        }
        public async Task<IActionResult> AddRoles()
        {
            foreach (var role in Enum.GetValues(typeof(RolesEnum)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }

            }
            return Content("role elave olundu");

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
