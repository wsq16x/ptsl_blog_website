using System.ComponentModel.DataAnnotations;

namespace blog_website.Dtos
{
    public class BlogPostDto : BlogPostEditDto
    {
       
    }

    public class BlogPostCreateDto
    {
        public string AuthorId { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
    }

    public class BlogPostEditDto : BlogPostCreateDto
    {
        [Required]
        public int Id { get; set; }

    }
}
