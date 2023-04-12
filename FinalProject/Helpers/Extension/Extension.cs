using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FinalProject.Helpers.Extension
{
    public static class Extension
    {
        public static bool CheckImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool CheckImageSize(this IFormFile file, int size)
        {
            return file.Length / 1024 > size;
        }

        public static string SaveImage(this IFormFile file, IWebHostEnvironment _env, string folder)
        {
            string fileName = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(_env.WebRootPath, folder, fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }


        public static void AddSomeServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                //options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
                options.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IBasketCount, BasketCountService>();
        }

        public static bool IsRegisteredEmail(this AppDbContext dbContext, string email)
        {
            var existingEmail = dbContext.Subscribes.FirstOrDefault(e => e.Email == email);
            return existingEmail != null;
        }

        public static void SaveEmail(this AppDbContext dbContext, string email)
        {
            var newEmail = new Models.Subscribe { Email = email };
            dbContext.Subscribes.Add(newEmail);
            dbContext.SaveChanges();
        }
    }
}
