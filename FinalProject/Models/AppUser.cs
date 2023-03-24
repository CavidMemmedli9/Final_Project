using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public List<Blog> Blog { get; set; }
    }
}
