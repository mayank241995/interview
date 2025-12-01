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
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }
        public DbSet<Fluent_Book> fluent_Books { get; set; }
        public DbSet<Fluent_Author> fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> fluent_Publishers { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=ATMECSBLRLT-262\\MSSQLSERVER1;Database=Interview;TrustServerCertificate=True;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fluent_BookDetail>().ToTable("fluent_BookDetail");

            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapter");

            //required property using fluent API
            modelBuilder.Entity<Fluent_BookDetail>().Property(u=>u.NumberOfChapters).IsRequired();
            //set primary key using fluent API
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
            //one to one mapping using fluent API
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(o => o.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(u=>u.IDBook);
            //one to many mapping using fluent API
            modelBuilder.Entity<Fluent_Book>().HasOne(o=>o.Publisher).WithMany(b=>b.Books).HasForeignKey(u => u.Publisher_Id);

            //max length using fluent API
            modelBuilder.Entity<Fluent_Book>().Property(o=>o.ISBN).HasMaxLength(50).IsRequired();
            //set primary key using fluent API
            modelBuilder.Entity<Fluent_Book>().HasKey(o => o.IDBook);

            modelBuilder.Entity<Fluent_Book>().Ignore(o => o.PriceRange);

           

            // setting precision for Price property in Book entity
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);

            //composite key
            modelBuilder.Entity<BookAuthorMap>().HasKey(b => new{ b.Author_Id,b.IDBook});

            modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(b => new{ b.Author_Id,b.IDBook});

            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u=>u.Book).WithMany(p=>p.BookAuthorMap).HasForeignKey(u=>u.IDBook);
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u=>u.Author).WithMany(p=>p.BookAuthorMap).HasForeignKey(u=>u.Author_Id);





            //primary key
            modelBuilder.Entity<Fluent_Author>().HasKey(o => o.Author_Id);
            // required and maxleght
            modelBuilder.Entity<Fluent_Author>().Property(o=>o.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(o=>o.LastName).IsRequired();
            //not mapped 
            modelBuilder.Entity<Fluent_Author>().Ignore(o => o.FullName);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(o => o.Publisher_Id);

            modelBuilder.Entity<Fluent_Publisher>().Property(o=>o.Name).IsRequired();



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
