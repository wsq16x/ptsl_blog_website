using blog_website.Dtos;
using blog_website.Models;
using blog_website.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Security.Claims;

namespace blog_website.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogPostService _blogPostService;


        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;

        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _blogPostService.GetUserBlogPosts(userId);
            
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var blogPost = new BlogPostCreateDto();

            return View(blogPost);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostById(id);

            var editDto = new BlogPostEditDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content
            };

            return View(editDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostById(id);

            return View(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostCreateDto blogPost)
        {
            var authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            blogPost.AuthorId = authorId;

            await _blogPostService.AddPost(blogPost);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogPostEditDto blogPost)
        {
            await _blogPostService.EditPost(blogPost);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _blogPostService.DeletePost(id);

            return RedirectToAction("Index");
        }
    }
}
