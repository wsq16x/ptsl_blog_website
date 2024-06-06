using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_website.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public string AuthorId { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public virtual ApplicationUser Author { get; set; } = null!;
        public virtual ICollection<BlogComment> Comments { get; set; } = null!;
    }
}
