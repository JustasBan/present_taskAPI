using System.ComponentModel.DataAnnotations;

namespace API_internship
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
