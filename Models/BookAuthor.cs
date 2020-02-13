using System;

namespace WebApplication.Models
{
    public class BookAuthor
    {
        protected bool Equals(BookAuthor other)
        {
            return BookAuthorId == other.BookAuthorId && AuthorId == other.AuthorId && BookId == other.BookId;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BookAuthor) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookAuthorId, AuthorId, BookId);
        }

        public int BookAuthorId { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }  

        public int BookId { get; set; }
        public Book? Book { get; set; } 

    }
}