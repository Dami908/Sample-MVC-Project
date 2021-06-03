using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext dbContext = app.ApplicationServices.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            if (!dbContext.Books.Any())
            {
                dbContext.Books.AddRange
                (
                    new Book { ISBN = 10101010, AuthorName = "John", BookTitle = "The hobbit", Amount = 50,Quantity=30 },
                    new Book { ISBN = 20202020, AuthorName = "James", BookTitle = "The Conjuring", Amount = 10, Quantity=60 }
                );
            }
            dbContext.SaveChanges();
        }
        
    }
}
