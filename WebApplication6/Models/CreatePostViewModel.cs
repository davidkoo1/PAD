using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class CreatePostViewModel
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string  Content { get; set; }
    }
}
