using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBase _db;
        private string Search { get; set; } = "";
        [BindProperty] public IEnumerable<int> AuthorIds { get; set; }

        public HomeController(DataBase db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["Publisher"] = new SelectList(_db.Publishers, "PublisherId", "PublisherName");
            ViewBag.AuthorSelectList= new SelectList(
                await _db.Authors.OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToListAsync(),
                nameof(Author.AuthorId), nameof(Author.FirstLastName));
            ViewBag.AuthorIds = AuthorIds;
            Search = search;
           

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower().Trim();

                return View(await _db.Books
                    .Include(b => b.Publisher)
                    .Include(b => b.BookAuthors)
                    .ThenInclude(b => b.Author)
                    .Include(b => b.Comments)
                    .Where(b =>
                        b.BookTitle.ToLower().Contains(search) ||
                        b.Publisher.PublisherName.ToLower().Contains(search) ||
                        b.Comments.Any(c => c.CommentText.ToLower().Contains(search)) ||
                        b.BookAuthors.Any(d =>
                            d.Author.FirstName.ToLower().Contains(search) ||
                            d.Author.LastName.ToLower().Contains(search))
                    )
                    .ToListAsync());
            }

            return View(await _db.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors)
                .ThenInclude(b => b.Author)
                .Include(b => b.Comments)
                .ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Book book)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            
                book.BookAuthors = new List<BookAuthor>();
                foreach (var authorId in AuthorIds)
                {
                    book.BookAuthors.Add(new BookAuthor{Book = book, AuthorId = authorId});
                }
                if (book.BookId == 0)
                {
                    _db.Books.Add(book);
                }
                else
                {
                    _db.Books.Update(book);
                }


            await _db.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

      


        public async Task<IActionResult> Delete(int? id)
        {
            var book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}