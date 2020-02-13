using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.DAL;

namespace WebApplication.Models
{
    public class PublisherController : Controller
    {
        public DataBase _db { get; set; }
        public PublisherController(DataBase db)
        {
            _db = db;
        }

        
        // GET
        [Route("/Publisher")]
        public async Task<IActionResult> Index()
        {
            return View(await _db.Publishers.Include(publisher => publisher.Books).ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var publisher = await _db.Publishers.FindAsync(id);
            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddOrEdit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if (publisher.PublisherId == 0)
                    _db.Add(publisher);
                else
                    _db.Update(publisher);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}