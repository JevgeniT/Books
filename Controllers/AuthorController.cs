using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly DataBase _db;
        // GET
        public AuthorController(DataBase db)
        {
            _db = db;
        }

        [Route("/Authors")]
        public async Task<IActionResult> Index()
        {
            return View(await _db.Authors
                .Include(author => author.AuthorBooks)
                .ThenInclude(author => author.Book)
                .ToListAsync());
        }

        public async Task<IActionResult> AddOrEdit(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.AuthorId == 0)
                    _db.Add(author);
                else
                    _db.Update(author);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            var author =await _db.Authors.FindAsync(id);
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }    
}


