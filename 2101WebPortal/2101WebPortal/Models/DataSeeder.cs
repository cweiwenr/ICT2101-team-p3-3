using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public static class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Facilitators.Any())
                {
                    return;
                }

                context.Facilitators.AddRange(
                    new Facilitator { 
                        Username = "admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                        IsSystemAdmin = true
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
