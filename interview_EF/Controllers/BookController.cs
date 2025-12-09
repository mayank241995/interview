using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
            foreach (var obj in objList)
            {
                //less effeicient
                //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
                //more effeicient
                _db.Entry(obj).Reference(i=>i.Publisher).Load();

            }
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
    }
}
