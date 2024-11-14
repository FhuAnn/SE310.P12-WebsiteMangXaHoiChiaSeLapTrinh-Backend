using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class PosttagsController : ControllerBase
    {
        private readonly IPosttagRepository posttagRepository;
        private readonly IMapper mapper;

        public PosttagsController(IPosttagRepository posttagRepository, IMapper mapper)
        {
            this.posttagRepository = posttagRepository;
            this.mapper = mapper;
        }

        // GET: api/Posttags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosttagDto>>> GetPosttags()
        {
            var posttag = await posttagRepository.GetAllAsync();

            var posttagDto = mapper.Map<IEnumerable<PosttagDto>>(posttag);

            return Ok(posttagDto);
        }

        
        // POST: api/Posttags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PosttagDto>> PostPosttag(PosttagDto posttagDto)
        {
            var posttag = mapper.Map<Posttag>(posttagDto);

            posttag = await posttagRepository.CreateAsync(posttag);

            var posttagDtoCreate = mapper.Map<PosttagDto>(posttag);
            
            return CreatedAtAction("GetPosttag", new { id = posttagDtoCreate.PostId }, posttagDtoCreate);
        }

        
    }
}
