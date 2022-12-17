using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using enoca.Data;
using enoca.Models;

namespace enoca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly FirmaContext _context;

        public FirmaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: api/Firma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firma>>> GetFirma()
        {
            return await _context.Firma.ToListAsync();
        }

        // GET: api/Firma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Firma>> GetFirma(Guid id)
        {
            var firma = await _context.Firma.FindAsync(id);

            if (firma == null)
            {
                return NotFound();
            }

            return firma;
        }

        // PUT: api/Firma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirma(Guid id, Firma firma)
        {
            if (id != firma.Id)
            {
                return BadRequest();
            }

            _context.Entry(firma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmaExists(id))
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

        // POST: api/Firma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Firma>> PostFirma(Firma firma)
        {
            _context.Firma.Add(firma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirma", new { id = firma.Id }, firma);
        }

        // DELETE: api/Firma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirma(Guid id)
        {
            var firma = await _context.Firma.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }

            _context.Firma.Remove(firma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FirmaExists(Guid id)
        {
            return _context.Firma.Any(e => e.Id == id);
        }
    }
}
