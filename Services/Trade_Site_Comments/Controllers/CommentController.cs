using Microsoft.AspNetCore.Mvc;
using Trade_Site_Comments.DTOs;
using Trade_Site_Comments.Services;

namespace Trade_Site_Comments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentAll()
        {
            var values = await _commentService.GetCommentAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _commentService.GetCommentById(id);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentDto addCommentDto)
        {
            await _commentService.AddComment(addCommentDto);
            return Ok("Comment added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _commentService.Update(updateCommentDto);
            return Ok("Comment updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);
            return Ok("Comment deleted successfully");
        }

        [HttpGet("GetCommentWithProduct")]
        public async Task<IActionResult> GetCommentWithProduct(string id)
        {
            var values = await _commentService.GetCommentWithProduct(id);
            return Ok(values);
        }
    }
}
