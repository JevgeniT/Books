using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class DataBase: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Publisher> Publishers { get; set; }



        public DataBase(DbContextOptions options) : base(options)
        {
            
        }
    }
}