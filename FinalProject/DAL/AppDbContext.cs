using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet <About> About { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<Slider> Slider { get; set; }

        public DbSet<Statics> Statics { get; set; }
    }
}
