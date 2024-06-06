using blog_website.Dtos;
using blog_website.Models;

namespace blog_website.Services
{
    public interface IBlogCommentService
    {
        Task<List<BlogComment>> GetBlogPostComments(int blogId);
        Task AddComment(BlogCommentCreateDto comment);
        Task EditComment(BlogCommentEditDto comment);
        Task DeleteComment(int id);
    }
}
