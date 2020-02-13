using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [MaxLength(128)] [MinLength(4)] [Display(Name = "First name")]
        public string FirstName { get; set; } 

        [MaxLength(128)] [MinLength(4)] [Display(Name = "Last name")]
        public string LastName { get; set; } 
        
        [Display(Name = "Year of birth")] 
        public int YearOfBirth { get; set; }

        [Display(Name = "Author books")]
        public ICollection<BookAuthor>? AuthorBooks { get; set; }
        
        public string FirstLastName => FirstName + " " + LastName;



    }
}

