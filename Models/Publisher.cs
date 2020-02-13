using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [MaxLength(128)] [MinLength(1)] [Display(Name = "Publisher name")]
        public string PublisherName { get; set; } 

        public ICollection<Book>? Books { get; set; }

    }
}