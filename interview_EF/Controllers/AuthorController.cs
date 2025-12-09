using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System.Threading.Tasks;

namespace interview_EF.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> Author = _db.Authors.ToList();

            return View(Author);
        }
        public IActionResult Upsert(int? id)
        {
            Author obj = new();
            if(id==null ||id==0)
            {
                return View(obj);
            }
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
                return NotFound();

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    await _db.Authors.AddAsync(obj);
                }
                else
                {
                    _db.Authors.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            Author obj = new();
            obj = await _db.Authors.FirstOrDefaultAsync(u => u.Author_Id == id);
            if(obj==null)
            {
                return NotFound();
            }
            _db.Authors.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
