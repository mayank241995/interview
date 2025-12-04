using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System.Threading.Tasks;

namespace interview_EF.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if(id==null || id==0)
            {
                return View(obj);
            }
            //edit
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult >Upsert(Category obj)
        {
            if(ModelState.IsValid)
            {
                if(obj.CategoryId==0)
                {
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                     _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            Category obj = new();
            //edit
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult CreateMultiple2()
        {
            List<Category> Category = new();
            for (int i = 0; i < 2; i++)
            {
                Category.Add(new Category
                {
                    CategoryName = Guid.NewGuid().ToString()
                });
            }
            _db.Categories.AddRange(Category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateMultiple5()
        {
            List<Category> Category = new();
            for (int i = 0; i < 5; i++)
            {
                Category.Add(new Category
                {
                    CategoryName = Guid.NewGuid().ToString()
                });
            }
            _db.Categories.AddRange(Category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple2()
        {
            List<Category> Category = _db.Categories.OrderByDescending(u=>u.CategoryId).Take(2).ToList();
            
            _db.Categories.RemoveRange(Category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> Category =_db.Categories.OrderByDescending(u=>u.CategoryId).Take(5).ToList();
            _db.Categories.RemoveRange(Category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
