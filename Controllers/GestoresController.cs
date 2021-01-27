using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_gestores.NET.Context;
using api_gestores.NET.Models;

namespace api_gestores.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GestoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Gestores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gestores_bd>>> GetGestores_bd()
        {
            return await _context.Gestores_bd.ToListAsync();
        }

        // GET: api/Gestores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gestores_bd>> GetGestores_bd(int id)
        {
            var gestores_bd = await _context.Gestores_bd.FindAsync(id);

            if (gestores_bd == null)
            {
                return NotFound();
            }

            return gestores_bd;
        }

        // PUT: api/Gestores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestores_bd(int id, Gestores_bd gestores_bd)
        {
            if (id != gestores_bd.id)
            {
                return BadRequest();
            }

            _context.Entry(gestores_bd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gestores_bdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(gestores_bd);
        }

        // POST: api/Gestores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gestores_bd>> PostGestores_bd(Gestores_bd gestores_bd)
        {
            _context.Gestores_bd.Add(gestores_bd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGestores_bd", new { id = gestores_bd.id }, gestores_bd);
        }

        // DELETE: api/Gestores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestores_bd(int id)
        {
            var gestores_bd = await _context.Gestores_bd.FindAsync(id);
            if (gestores_bd == null)
            {
                return NotFound();
            }

            _context.Gestores_bd.Remove(gestores_bd);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        private bool Gestores_bdExists(int id)
        {
            return _context.Gestores_bd.Any(e => e.id == id);
        }
    }
}
