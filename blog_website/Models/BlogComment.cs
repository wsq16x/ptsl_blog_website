using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_website.Models
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; } = null!;

        public int BlogPostId { get; set; }
        public string? UserId { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual BlogPost BlogPost { get; set; } = null!;
    }
}
