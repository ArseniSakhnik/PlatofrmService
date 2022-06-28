using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlatofrmService.Models;

namespace PlatofrmService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Platform>().HasData(new List<Platform>
            {
                new()
                {
                    Id = 1,
                    Name = "Dot Net",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new()
                {
                    Id = 2,
                    Name = "SQL Server Express",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new()
                {
                    Id = 3,
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computing Foundation",
                    Cost = "Free"
                }
            });

            base.OnModelCreating(builder);
        }
    }
}