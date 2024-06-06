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
        public async Task<IActionResult> AddComment([FromBody] BlogCommentCreateDto commentDto)
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
                return StatusCode(500, new { message = "An error occurred while adding the comment.", error = ex.Message });

            }

            return Ok(new { message = "Comment added successfully." });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditComment([FromBody]BlogCommentEditDto commentDto)
        {

            try
            {
                await _blogCommentService.EditComment(commentDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new { message = "An error occurred while editing the comment.", error = ex.Message });

            }

            return Ok(new { message = "Comment edited successfully." });
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                await _blogCommentService.DeleteComment(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new { message = "An error occurred while deleting the comment.", error = ex.Message });

            }

            return Ok(new { message = "Comment deleted successfully." });
        }
    }
}
