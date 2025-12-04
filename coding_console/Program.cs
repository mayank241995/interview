// See https://aka.ms/new-console-template for more information
using DataAccess.Data;
using DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using Model.Models;

Console.WriteLine("Hello, World!");

////using (ApplicationDbContext context = new())
////{
////    context.Database.EnsureCreated();

////    if(context.Database.GetPendingMigrations().Count() > 0)
////    {
////        context.Database.Migrate();
////    }
////}
//GetAllBooks();
////AddBookToDb();
//GetBook();
////updateToDb();
//DeleteToDB();

//void DeleteToDB()
//{
//    using var context = new ApplicationDbContext();
//    var book = context.Books.Find(1);
//}

//void updateToDb()
//{
//    try
//    {
//        using var context=new ApplicationDbContext();
//        var book = context.Books.Find(1);
//        context.Books.Remove(book);
//        context.SaveChanges();

//    }
//    catch(Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

////void GetBook()
////{
////    using var context= new ApplicationDbContext();
////    //var b=context.Books.Where(u=>u.Publisher_Id==1).FirstOrDefault();
////    var bo = context.Books.Where(u => EF.Functions.Like(u.ISBN,"12%"));
////    //  var b2 = context.Books.First();
////    // var b=context.fluent_Books.FirstOrDefault();
////    // Console.WriteLine($"Bookid : {b.IDBook} Title : {b.Title} Price : {b.Price}");
////    foreach (var b in bo)
////    {
////        Console.WriteLine($"Bookid : {b.IDBook} Title : {b.Title} Price : {b.Price} ISBN : {b.ISBN}");

////    }
////}
//void GetBook()
//{
//    using var context = new ApplicationDbContext();
//    var bo = context.Books.OrderBy(u=>u.Title).OrderByDescending(u=>u.Title);
//    foreach (var b in bo)
//    {
//        Console.WriteLine($"Bookid : {b.IDBook} Title : {b.Title} Price : {b.Price} ISBN : {b.ISBN}");

//    }
//}


//void GetAllBooks()
//{
//   using var context = new ApplicationDbContext();
//    var book = context.Books.ToList();
//    foreach(var b in book)
//    {
//        Console.WriteLine($"Bookid : {b.IDBook} Title : {b.Title} Price : {b.Price}");
        
//    }
//}
//void AddBookToDb()
//{
//    Book book = new() { Title = "Dotnet Spray", ISBN = "12435645", Price = 90.0m ,Publisher_Id=1};
//    using var context = new ApplicationDbContext();
//    var addBook = context.Books.Add(book);
//    context.SaveChanges();
//}