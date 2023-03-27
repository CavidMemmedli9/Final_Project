﻿using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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

        public DbSet<Background> Background { get; set; }
        public DbSet<Choose> Choose { get; set; }

        public DbSet<Cleaning_Services> Cleaning_Services { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Related_Provider> Related_Provider { get; set; }

        public DbSet<News_Articles> News_Articles { get; set; }
        public DbSet<AboutProvider> AboutProvider { get; set; }

        public DbSet<Vacancy> Vacancy { get; set; }

        public DbSet<JobInfo> JobInfo { get; set; }
        public DbSet<Blog> Blog { get; set; }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Photos> Photos { get; set; }


        public DbSet<Settings> Settings { get; set; }
    }
}
