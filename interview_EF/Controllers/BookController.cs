using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.ViewModel;
using System.Threading.Tasks;

namespace interview_EF.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        // multiple time hit db
        //public IActionResult Index()
        //{
        //   // List<Book> objList = _db.Books.Include(b => b.Publisher).ToList();
        //   List<Book> objList = _db.Books.ToList();
        //    foreach (var obj in objList)
        //    {
        //    //    //less effeicient
        //    //    //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
        //    //    //more effeicient
        //          _db.Entry(obj).Reference(i=>i.Publisher).Load();
        //          _db.Entry(obj).Collection(i=>i.Authors).Load();
        //        foreach (var bookAuth in obj.Authors)
        //        {
        //            _db.Entry(bookAuth).Reference(i => i.Author).Load();
        //        }
        //    }
        //    return View(objList);
        //}
        public IActionResult Index()
        {
             List<Book> objList = _db.Books.Include(b => b.Publisher).Include(u=>u.Authors).ThenInclude(i=>i.Author).ToList();

            //List<Book> objList = _db.Books.ToList();
            //foreach (var obj in objList)
            //{
            //    //    //less effeicient
            //    //    //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
            //    //    //more effeicient
            //    _db.Entry(obj).Reference(i => i.Publisher).Load();
            //    _db.Entry(obj).Collection(i => i.Authors).Load();
            //    foreach (var bookAuth in obj.Authors)
            //    {
            //        _db.Entry(bookAuth).Reference(i => i.Author).Load();
            //    }
            //}
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text= i.Name,
                Value=i.Publisher_Id.ToString()
            });
            if (id == null || id == 0)
            {
                return View(obj);
            }
            //edit
            obj.Book = _db.Books.FirstOrDefault(u => u.IDBook == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
            
           
                if (obj.Book.IDBook == 0)
                {
                    await _db.Books.AddAsync(obj.Book);
                }
                else
                {
                    _db.Books.Update(obj.Book);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            
           // return View(obj);
        }
        public IActionResult Details(int? id)
        {
            //BookVM obj = new();

            BookDetail obj = new();

            if (id == null || id == 0)
            {
                return NotFound();
            }
            //edit
            //obj.Book = _db.Books.FirstOrDefault(u => u.IDBook == id);
            obj = _db.BookDetails.Include(o=>o.Book).FirstOrDefault(u => u.IDBook == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {

           
            if (obj.BookDetail_Id == 0)
            {
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                _db.BookDetails.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

            // return View(obj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            Book obj = new();
            //edit
            obj = _db.Books.FirstOrDefault(u => u.IDBook == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new()
            {
                BookAuthorList = _db.BookAuthorMaps.Include(u=>u.Author).Include(u=>u.Book)
                .Where(u => u.IDBook == id).ToList(),
                BookAuthor =new()
                {
                    IDBook=id
                },
                Book=_db.Books.FirstOrDefault(u => u.IDBook == id), 
            };
            List<int> tempListAssignAuthor=obj.BookAuthorList.Select(u => u.Author_Id).ToList();
            //not IN Clause
            //get all the authors whos id is not in tempListOfAssignedAuthor 
            var tempList = _db.Authors.Where(u => !tempListAssignAuthor.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text=i.FullName,
                Value=i.Author_Id.ToString()
            });
            return View(obj);
        }
        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if(bookAuthorVM.BookAuthor.IDBook!=0 && bookAuthorVM.BookAuthor.Author_Id!=0)
            {
                _db.BookAuthorMaps.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors),new { @id= bookAuthorVM.BookAuthor.IDBook});
        }
        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVM bookAuthorVM)
        {
            int bookID=bookAuthorVM.Book.IDBook;
            BookAuthorMap bookAuthorMap = _db.BookAuthorMaps.FirstOrDefault(u => u.Author_Id ==authorId && u.IDBook == bookID);

           
                _db.BookAuthorMaps.Remove(bookAuthorMap);
                _db.SaveChanges();
            
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookID });
        }
    }
}
