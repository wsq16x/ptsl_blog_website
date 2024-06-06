using blog_website.Data;
using blog_website.Dtos;
using blog_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace blog_website.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly ApplicationDbContext _context;

        public BlogPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(BlogPostCreateDto post)
        {
            var blogPost = new BlogPost
            {
                Title = post.Title,
                Content = post.Content,
                AuthorId = post.AuthorId,
                CreatedAt = DateTime.Now
            };

            await _context.BlogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                throw new KeyNotFoundException(nameof(blogPost));
            }

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
        }

        public async Task EditPost(BlogPostEditDto post)
        {
            var blogPost = await _context.BlogPosts.FindAsync(post.Id);

            if(blogPost == null)
            {
                throw new KeyNotFoundException(nameof(blogPost));
            }

            blogPost.Title = post.Title;
            blogPost.Content = post.Content;
            blogPost.LastUpdatedAt = DateTime.Now;

            _context.BlogPosts.Update(blogPost);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BlogPost>> GetAllBlogPosts()
        {
            var blogPosts = await _context.BlogPosts.ToListAsync();
            
            return blogPosts;
        }

        public async Task<BlogPost> GetBlogPostById(int id)
        {
            var blogPost = await _context.BlogPosts.Include(x => x.Comments).ThenInclude(y => y.User).Include(x => x.Author).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (blogPost == null)
            {
                throw new KeyNotFoundException(nameof(blogPost));
            }

            return blogPost;
        }

        public async Task<List<BlogPost>> GetUserBlogPosts(string id)
        {
            var blogPosts = await _context.BlogPosts.Where(x => x.AuthorId == id).ToListAsync();

            return blogPosts;
        }
    }
}
