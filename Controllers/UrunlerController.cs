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
    public class UrunlerController : ControllerBase
    {
        private readonly UrunlerContext _context;

        public UrunlerController(UrunlerContext context)
        {
            _context = context;
        }

        // GET: api/Urunler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urunler>>> GetUrunler()
        {
            return await _context.Urunler.ToListAsync();
        }

        // GET: api/Urunler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urunler>> GetUrunler(Guid id)
        {
            var urunler = await _context.Urunler.FindAsync(id);

            if (urunler == null)
            {
                return NotFound();
            }

            return urunler;
        }

        // PUT: api/Urunler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrunler(Guid id, Urunler urunler)
        {
            if (id != urunler.Id)
            {
                return BadRequest();
            }

            _context.Entry(urunler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunlerExists(id))
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

        // POST: api/Urunler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Urunler>> PostUrunler(Urunler urunler)
        {
            _context.Urunler.Add(urunler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrunler", new { id = urunler.Id }, urunler);
        }

        // DELETE: api/Urunler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrunler(Guid id)
        {
            var urunler = await _context.Urunler.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }

            _context.Urunler.Remove(urunler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UrunlerExists(Guid id)
        {
            return _context.Urunler.Any(e => e.Id == id);
        }
    }
}
