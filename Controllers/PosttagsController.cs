using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosttagsController : ControllerBase
    {
        private readonly StackOverflowDBContext _context;

        public PosttagsController(StackOverflowDBContext context)
        {
            _context = context;
        }

        // GET: api/Posttags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posttag>>> GetPosttags()
        {
            return await _context.Posttags.ToListAsync();
        }

        // GET: api/Posttags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Posttag>> GetPosttag(Guid id)
        {
            var posttag = await _context.Posttags.FindAsync(id);

            if (posttag == null)
            {
                return NotFound();
            }

            return posttag;
        }

        // PUT: api/Posttags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosttag(Guid id, Posttag posttag)
        {
            if (id != posttag.PostId)
            {
                return BadRequest();
            }

            _context.Entry(posttag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosttagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posttags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Posttag>> PostPosttag(Posttag posttag)
        {
            _context.Posttags.Add(posttag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PosttagExists(posttag.PostId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPosttag", new { id = posttag.PostId }, posttag);
        }

        // DELETE: api/Posttags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosttag(Guid id)
        {
            var posttag = await _context.Posttags.FindAsync(id);
            if (posttag == null)
            {
                return NotFound();
            }

            _context.Posttags.Remove(posttag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PosttagExists(Guid id)
        {
            return _context.Posttags.Any(e => e.PostId == id);
        }
    }
}
