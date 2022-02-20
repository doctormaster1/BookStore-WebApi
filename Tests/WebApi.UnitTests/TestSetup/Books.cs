using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup{
    public static class Books{
        public static void AddBooks(this IBookStoreDbContext context){
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
        }
    }
}
