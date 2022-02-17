using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations{
    public class DataGenerator{
        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())){
                if(context.Books.Any()){
                    return;
                }

                context.Authors.AddRange(
                    new Author{
                        Name = "Oscar",
                        Lastname = "Wilde",
                        Birthdate = new DateTime(1945,04,23)
                    },
                    new Author{
                        Name = "Franz",
                        Lastname = "Kafka",
                        Birthdate = new DateTime(1948,08,13)
                    },
                    new Author{
                        Name = "George",
                        Lastname = "Orwell",
                        Birthdate = new DateTime(1965,11,30)
                    }
                );

                context.Genres.AddRange(
                    new Genre{
                        Name = "Personal Growth"
                    },
                    new Genre{
                        Name = "Science Fiction"
                    },
                    new Genre{
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book{
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate =  new DateTime(2001,06,12)
                    },
                    new Book{
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate =  new DateTime(2010,05,23)
                    },
                    new Book{
                        Title = "Dune",
                        GenreId = 3,
                        PageCount = 550,
                        PublishDate =  new DateTime(2001,12,21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
