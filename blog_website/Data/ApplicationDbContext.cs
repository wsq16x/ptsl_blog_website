using Azure.Identity;
using blog_website.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blog_website.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<BlogComment> BlogComments { get; set; }
    }
}
