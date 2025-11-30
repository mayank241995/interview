using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=ATMECSBLRLT-262\\MSSQLSERVER1;Database=Interview;TrustServerCertificate=True;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setting precision for Price property in Book entity
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);
            //creating entry
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    IDBook = 1,
                    Title = "Sample Book",
                    ISBN = "123-4567890123",
                    Price = 19.99000m,
                    Publisher_Id=1
                },
               new Book
               {
                   IDBook = 2,
                   Title = "Another Book",
                   ISBN = "987-6543210987",
                   Price = 29.99500m,
                   Publisher_Id=2
               }
            );
            var bookList = new Book[]
            {
                new Book{IDBook=3,Title="C# Programming",ISBN="111-2223334445",Price=39.99000m,Publisher_Id=1},
                new Book{IDBook=4,Title="ASP.NET Core Guide",ISBN="555-6667778889",Price=49.99500m,Publisher_Id = 2},
                new Book{IDBook=5,Title="Entity Framework Core",ISBN="999-0001112223",Price=59.99000m, Publisher_Id = 3}
            };
            modelBuilder.Entity<Book>().HasData(bookList);
            modelBuilder.Entity<Publisher>().HasData(
               new Publisher
               {
                   Publisher_Id = 1,Location="Chicago",Name="pub 1 jimmy"
               },
               new Publisher
               {
                   Publisher_Id = 2,Location="New York",Name="pub 2 jhon"
               },
               new Publisher
               {
                   Publisher_Id = 3,Location="New York",Name = "pub 2 jhon"
               }
            );


        }
    }
}
