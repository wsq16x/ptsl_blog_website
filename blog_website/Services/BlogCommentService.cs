using blog_website.Data;
using blog_website.Dtos;
using blog_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace blog_website.Services
{
    public class BlogCommentService : IBlogCommentService
    {
        private readonly ApplicationDbContext _context;

        public BlogCommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddComment(BlogCommentCreateDto comment)
        {
            var newComment = new BlogComment
            {
                BlogPostId = comment.BlogPostId,
                Comment = comment.Comment,
                UserId = comment.UserId,
                CreatedAt = DateTime.Now,
            };

            await _context.BlogComments.AddRangeAsync(newComment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _context.BlogComments.FindAsync(id);

            if (comment == null)
            {
                throw new KeyNotFoundException(nameof(comment));
            }

            _context.BlogComments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task EditComment(BlogCommentEditDto comment)
        {
            var editComment = await _context.BlogComments.FindAsync(comment.Id);

            if (editComment == null)
            {
                throw new KeyNotFoundException(nameof(editComment));
            }

            editComment.Comment = comment.Comment;
            editComment.LastUpdatedAt = DateTime.Now;

            _context.BlogComments.Update(editComment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BlogComment>> GetBlogPostComments(int blogId)
        {
            var comments = await _context.BlogComments.Where(x => x.BlogPostId == blogId).ToListAsync();

            return comments;
        }
    }
}
