using blog_website.Dtos;
using blog_website.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace blog_website.Controllers
{
    public class CommentController : Controller
    {
        private readonly IBlogCommentService _blogCommentService;

        public CommentController(IBlogCommentService blogCommentService)
        {
            _blogCommentService = blogCommentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> AddComment(BlogCommentCreateDto commentDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            commentDto.UserId = userId;

            try
            {
                await _blogCommentService.AddComment(commentDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> EditComment(BlogCommentEditDto commentDto)
        {

            try
            {
                await _blogCommentService.EditComment(commentDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> DeleteComment(int id)
        {
            try
            {
                await _blogCommentService.DeleteComment(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}
