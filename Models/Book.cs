using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public int PublisherId { get; set; }
        [Required]
        [MaxLength(128)][MinLength(4)][Display(Name = "Title")]
        public string BookTitle { get; set; }

        public Publisher? Publisher { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        [Display(Name = "Book authors")]
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        
    }
}