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
                    return; //Checks if there are any data in the Facilitators table & populate the table if it is empty
                }

                //Add default system administrator account
                context.Facilitators.AddRange(
                    new Facilitator { 
                        Username = "admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                        IsSystemAdmin = true
                    }
                    );

                //Save changes into database
                context.SaveChanges();
            }
        }
    }
}
