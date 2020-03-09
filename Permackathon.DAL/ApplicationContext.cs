using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Permackathon.DAL.Entities;
using System;

namespace Permackathon.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationContext(){}

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            if (options is null)
                throw new ArgumentNullException("No options for the context!");
        }

        //DbSet
        public DbSet<Activity> Activities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<ActivitySite> ActivitySites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PermackathonDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ActivitySite>().HasKey(ac => new { ac.ActivityId, ac.SiteId });
            base.OnModelCreating(builder);
        }
    }
}