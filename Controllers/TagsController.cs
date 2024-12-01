using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        private readonly IWatchedTagRepository watchedTagRepository;
        private readonly IIgnoreTagRepository ignoreTagRepository;

        public TagsController(ITagRepository tagRepository, IMapper mapper, IWatchedTagRepository watchedTagRepository, IIgnoreTagRepository ignoreTagRepository)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
            this.watchedTagRepository = watchedTagRepository;
            this.ignoreTagRepository = ignoreTagRepository;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult> GetTags()
        {
            //Get Data from Database - Domain models
            var tagDomain = await tagRepository.GetTagsAsync();
            //Convert Domain to Dto
            return Ok(mapper.Map<List<TagDto>>(tagDomain));
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTagById(Guid id)
        {
            var tag = await tagRepository.GetByIdAsync(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(Guid id, UpdateTagRequestDto updateTagRequestDto)
        {
            var tagDomain = await tagRepository.UpdateAsync(t => t.Id == id, entity =>
            {
                entity.Tagname = updateTagRequestDto.Tagname;
                entity.Description = updateTagRequestDto.Description;
                entity.UpdatedAt = DateTime.Now;
            });
            return Ok(tagDomain);
        }

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(AddTagRequestDto addTagRequestDto)
        {
            var tagDomain = mapper.Map<Tag>(addTagRequestDto);
            var tagCreate = await tagRepository.CreateAsync(tagDomain);
            
            return CreatedAtAction("GetTag", new { id = tagCreate.Id }, tagCreate);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            await tagRepository.DeleteAsync(t => t.Id == id);
            

            return NoContent();
        }

        [HttpPost("watch")]
        public async Task<IActionResult> WatchTag(Guid userId, Guid tagId)
        {
            var watchedTag = new WatchedTag { UserId = userId, TagId = tagId };
            var existWatchedTag = await watchedTagRepository.GetByIdAsync(wt => wt.TagId == tagId && wt.UserId == userId);
            var existIgnoredTag = await ignoreTagRepository.DeleteAsync(it => it.TagId == tagId && it.UserId == userId);
            if (existWatchedTag != null)
            {
                return Content("Da co tag ");
            }

            var insertWatchedTag = await watchedTagRepository.CreateAsync(watchedTag);
            return Ok(insertWatchedTag != null ? "Theo doi tag thanh cong" : "Theo doi tag khong thanh cong");
        }

        [HttpPost("ignore")]
        public async Task<IActionResult> IgnoreTag(Guid userId, Guid tagId)
        {
            var ignoredTag = new IgnoredTag { UserId = userId, TagId = tagId };
            var existIgnoredTag = await ignoreTagRepository.GetByIdAsync(it => it.TagId == tagId && it.UserId == userId);
            var existWatchedTag = await watchedTagRepository.DeleteAsync(wt => wt.TagId == tagId && wt.UserId == userId);
            if (existIgnoredTag != null)
            {
                return Content("Da co tag ");
            }

            var insertIgnoredTag = await ignoreTagRepository.CreateAsync(ignoredTag);
            return Ok(insertIgnoredTag != null ? "Bo theo doi tag thanh cong" :"Bo theo doi tag khong thanh cong");
        }

        [HttpDelete("unwatch")]
        public async Task<IActionResult> UnwatchTag(Guid userId, Guid tagId)
        {
            var result = await watchedTagRepository.DeleteAsync(wt => wt.UserId == userId && wt.TagId == tagId);
            if (result != null)
                return Ok("Xoa thanh cong");
            return Content("Co gi do sai sai");
        }

        [HttpDelete("unignore")]
        public async Task<IActionResult> UnignoreTag(Guid userId, Guid tagId)
        {
            var result = await ignoreTagRepository.DeleteAsync(wt => wt.UserId == userId && wt.TagId == tagId);
            if (result != null)
                return Ok("Xoa thanh cong");
            return Content("Co gi do sai sai");
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> SearchTag(string searchTerm)
        {
            var taglist = await tagRepository.SearchTagAsync(searchTerm);
            return Ok(taglist);
        }
    }
}
