using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetSandbox.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there.");
                }
                else
                {
                    applicationDbContext.Add(new Book
                    {
                        Id = 1,
                        Title = "Harry Potter and the Goblet of Fire",
                        Author = "JK Rowling",
                        Language = "English",
                    });
                    Console.WriteLine("Added book with title: Harry Potter and the Goblet of Fire");
                    applicationDbContext.Add(new Book
                    {
                        Id = 2,
                        Title = "The Happiest Man on Earth",
                        Author = "Eddie Jaku",
                        Language = "English",
                    });
                    Console.WriteLine("Added book with title: The Happiest Man on Earth");
                    applicationDbContext.SaveChanges();
                }
            }
        }
    }
}
