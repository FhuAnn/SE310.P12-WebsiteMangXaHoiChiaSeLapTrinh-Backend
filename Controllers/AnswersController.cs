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
    [Authorize]
    public class AnswersController : ControllerBase
    {
        private readonly StackOverflowDBContext _context;
        private readonly IAnswerRepository answerRepository;
        private readonly IMapper mapper;

        public AnswersController(StackOverflowDBContext context,IAnswerRepository answerRepository,IMapper mapper)
        {
            _context = context;
            this.answerRepository = answerRepository;
            this.mapper = mapper;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from Database - Domain models
            var answerDomain = await answerRepository.GetAllAsync();
            //Convert Domain to Dto
            return Ok(mapper.Map<List<AnswerDto>>(answerDomain));
        }
        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetById(Guid id)
        {
            //Get answer model from DB
            var answerDomain = await answerRepository.GetByIdAsync(x=>x.Id==id);

            if (answerDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
            return Ok(mapper.Map<AnswerDto>(answerDomain));
        }

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Answer>> CreateAnswer([FromBody]AddAnswerRequestDto addAnswerDto)
        {
            //Convert DTO to Domain Model
            var answerDomain = mapper.Map<Answer>(addAnswerDto);
            
            //Use Domain Model to create Answer
            answerDomain = await answerRepository.CreateAsync(answerDomain);
            
            //Convert Domain Model back to DTO
            var answerDto = mapper.Map<AnswerDto>(answerDomain);
            return CreatedAtAction(nameof(GetById), new { id = answerDto.Id }, answerDto);
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAnswer(Guid id, UpdateAnswerRequestDto updateAnswerRequestDto)
        {
            //Map DTO to Domain Model
            var answerDomain = mapper.Map<Answer>(updateAnswerRequestDto);
            
            //Check if region exits
            answerDomain = await answerRepository.UpdateAsync(x=> x.Id==id, entity =>
            {
                entity.Body = answerDomain.Body;
                entity.Id = answerDomain.Id;
            });
            if(answerDomain == null) { return NotFound(); }
            
            //Convert Domain Model to DTO
            return Ok(mapper.Map<AnswerDto>(answerDomain));

        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            //Check if region exits
            var answerDomain = await answerRepository.DeleteAsync(x=>x.Id==id);
            if(answerDomain == null) { return NotFound(); }

            //Map Domain Model to DTO
            return Ok(mapper.Map<Answer>(answerDomain));
        }

    }
}
