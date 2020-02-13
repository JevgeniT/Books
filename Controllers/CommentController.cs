using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.DAL;

namespace WebApplication.Models
{
    public class CommentController : Controller
    {
        
        public DataBase _db { get; set; }
          
        public CommentController(DataBase db)
        {
            _db = db;
        }

        
        [Route("/Comments/{id?}")]
        public async Task<IActionResult> Index(int? id)
        {
            return PartialView("CommentModal", await _db.Comments
                .Where(comment => comment.BookId == id)
                .ToListAsync());
        }
        
        [HttpPost]

        public async Task<IActionResult> AddOrEdit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                if (comment.CommentId == 0)
                    _db.Add(comment);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
        
    }
}