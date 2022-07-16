using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatofrmService.Models;

namespace PlatofrmService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform
                    {
                        Name = "Dot net",
                        Publisher = "Microsoft",
                        Cost = "Free"
                    },
                    new Platform
                    {
                        Name = "SQL Server Express",
                        Publisher = "Microsoft",
                        Cost = "Free"
                    },
                    new Platform
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud Native Computing Foundation",
                        Cost = "Free"
                    }
                );

                context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}