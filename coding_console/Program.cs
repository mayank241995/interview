// See https://aka.ms/new-console-template for more information
using DataAccess.Data;
using DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using Model.Models;

Console.WriteLine("Hello, World!");

//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();

//    if(context.Database.GetPendingMigrations().Count() > 0)
//    {
//        context.Database.Migrate();
//    }
//}
GetAllBooks();
//AddBookToDb();

void GetAllBooks()
{
   using var context = new ApplicationDbContext();
    var book = context.Books.ToList();
    foreach(var b in book)
    {
        Console.WriteLine($"Bookid : {b.IDBook} Title : {b.Title} Price : {b.Price}");
        
    }
}
void AddBookToDb()
{
    Book book = new() { Title = "Dotnet Spray", ISBN = "12435645", Price = 90.0m ,Publisher_Id=1};
    using var context = new ApplicationDbContext();
    var addBook = context.Books.Add(book);
    context.SaveChanges();
}