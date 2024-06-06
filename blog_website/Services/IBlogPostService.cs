using blog_website.Dtos;
using blog_website.Models;

namespace blog_website.Services
{
    public interface IBlogPostService
    {
        Task<List<BlogPost>> GetAllBlogPosts();
        Task<List<BlogPost>> GetUserBlogPosts(string id);
        Task<BlogPost> GetBlogPostById (int id);
        Task AddPost(BlogPostCreateDto post);
        Task EditPost(BlogPostEditDto post);
        Task DeletePost(int id);
    }
}
