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
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;
        [ForeignKey("BlogPostId")]
        public virtual BlogPost BlogPost { get; set; } = null!;
    }
}
