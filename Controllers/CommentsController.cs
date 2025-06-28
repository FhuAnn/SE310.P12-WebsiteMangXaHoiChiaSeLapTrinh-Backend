using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.CustomValidateFilters;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Services;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            this.mapper = mapper;
        }

        [HttpPost("post/{postId}")]
        public async Task<ActionResult<Comment>> AddCommentToPost(Guid postId, [FromBody] CommentRequest request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Lấy userId từ JWT token
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized("User ID is missing in the token.");
            }

            // Kiểm tra xem userId có phải là một GUID hợp lệ không
            if (!Guid.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID format.");
            }
            var comment = await _commentService.AddCommentToPostAsync(postId, request.Body, userId);
            var commentDto = mapper.Map<CommentDto>(comment);
            return Ok(commentDto);
        }

        [HttpPost("answer/{answerId}")]
        public async Task<ActionResult<Comment>> AddCommentToAnswer(Guid answerId, [FromBody] CommentRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var comment = await _commentService.AddCommentToAnswerAsync(answerId, request.Body, Guid.Parse(userId));
            var commentDto = mapper.Map<CommentDto>(comment);
            return Ok(commentDto);
        }

        

        [HttpGet("post/{postId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetPostComments(Guid postId)
        {
            var comments = await _commentService.GetCommentsByPostAsync(postId);
            var commentDto = mapper.Map<List<CommentDto>>(comments);
            return Ok(commentDto);
        }

        [HttpGet("answer/{answerId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAnswerComments(Guid answerId)
        {
            var comments = await _commentService.GetCommentsByAnswerAsync(answerId);
            var commentDto = mapper.Map<List<CommentDto>>(comments);

            return Ok(commentDto);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<Comment>> UpdateComment(Guid commentId, [FromBody] CommentRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updatedComment = await _commentService.UpdateCommentAsync(commentId, request.Body, Guid.Parse(userId));
            var commentDto = mapper.Map<CommentDto>(updatedComment);

            return Ok(commentDto);
        }

        // API endpoint xóa bình luận
        [HttpDelete("{commentId}")]
        public async Task<ActionResult> DeleteComment(Guid commentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _commentService.DeleteCommentAsync(commentId, Guid.Parse(userId));

            if (!result) return NotFound("Comment not found or you don't have permission to delete this comment.");
            return NoContent();
        }
    }
}
