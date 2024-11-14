using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   /* [Authorize]*/

    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from Database - Domain models
            var commentDomain = await commentRepository.GetAllAsync();
            //Convert Domain to Dto
            return Ok(mapper.Map<List<CommentDto>>(commentDomain));
        }
        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetById(Guid id)
        {
            //Get answer model from DB
            var commentDomain = await commentRepository.GetByIdAsync(x=>x.Id==id);

            if (commentDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
            return Ok(mapper.Map<CommentDto>(commentDomain));
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Comment>> CreateComment([FromBody] AddCommentRequestDto addCommentDto)
        {
            //Convert DTO to Domain Model
            var commentDomain = mapper.Map<Comment>(addCommentDto);

            //Use Domain Model to create Comment
            commentDomain = await commentRepository.CreateAsync(commentDomain);

            //Convert Domain Model back to DTO
            var CommentDto = mapper.Map<CommentDto>(commentDomain);
            return CreatedAtAction(nameof(GetById), new { id = CommentDto.Id }, CommentDto);
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateComment(Guid id, UpdateCommentRequestDto updateCommentRequestDto)
        {
            //Map DTO to Domain Model
            var commentDomain = mapper.Map<Comment>(updateCommentRequestDto);

            //Check if region exits
            commentDomain = await commentRepository.UpdateAsync(x => x.Id == id, entity =>
            {
                entity.Body = commentDomain.Body;
                entity.Id = commentDomain.Id;
            });
            if (commentDomain == null) { return NotFound(); }

            //Convert Domain Model to DTO
            return Ok(mapper.Map<CommentDto>(commentDomain));

        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            //Check if region exits
            var commentDomain = await commentRepository.DeleteAsync(x => x.Id == id);
            if (commentDomain == null) { return NotFound(); }

            //Map Domain Model to DTO
            return Ok(mapper.Map<Comment>(commentDomain));
        }

    }
}
