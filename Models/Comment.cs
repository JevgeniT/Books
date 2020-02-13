using System.ComponentModel.DataAnnotations;

 namespace WebApplication.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [MaxLength(1024)]
        [MinLength(1)][Display(Name = "Text")]
        public string CommentText { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }  

    }
}