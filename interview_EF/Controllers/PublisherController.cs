using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System.Threading.Tasks;

namespace interview_EF.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
             _db = db;
        }

        public IActionResult Index()
        {
            List<Publisher> Publisher = _db.Publishers.ToList();
            return View(Publisher);
        }
        public IActionResult Upsert(int? id)
        {
            Publisher obj = new();
            if(id== null || id==0)
            {
                return View(obj);
            }
            obj= _db.Publishers.FirstOrDefault(u=>u.Publisher_Id==id);
            if(obj== null)
            {
                return NotFound();
            }
            return View(obj);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult >Upsert(Publisher obj)
        {
            if(ModelState.IsValid)
            {
                if(obj.Publisher_Id==0)
                {
                    await _db.Publishers.AddAsync(obj);
                }
                else
                {
                    _db.Publishers.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
           Publisher obj=new();

            obj = await _db.Publishers.FirstOrDefaultAsync(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Publishers.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       
    }
}
