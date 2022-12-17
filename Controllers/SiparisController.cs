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
    public class SiparisController : ControllerBase
    {
        private readonly SiparisContext _context;

        public SiparisController(SiparisContext context)
        {
            _context = context;
        }

        // GET: api/Siparis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Siparis>>> GetSiparis()
        {
            return await _context.Siparis.ToListAsync();
        }

        // GET: api/Siparis/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Siparis>> GetSiparis(Guid id)
        {
            var siparis = await _context.Siparis.FindAsync(id);

            if (siparis == null)
            {
                return NotFound();
            }

            return siparis;
        }

        // PUT: api/Siparis/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiparis(Guid id, Siparis siparis)
        {
            if (id != siparis.Id)
            {
                return BadRequest();
            }

            _context.Entry(siparis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiparisExists(id))
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

        // POST: api/Siparis
        [HttpPost]
        public async Task<ActionResult<Siparis>> PostSiparis(Siparis siparis)
        {
            _context.Siparis.Add(siparis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiparis", new { id = siparis.Id }, siparis);
        }

        // DELETE: api/Siparis/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiparis(Guid id)
        {
            var siparis = await _context.Siparis.FindAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }

            _context.Siparis.Remove(siparis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SiparisExists(Guid id)
        {
            return _context.Siparis.Any(e => e.Id == id);
        }
    }
}
