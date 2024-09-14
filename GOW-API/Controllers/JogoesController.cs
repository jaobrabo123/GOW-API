using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GOW_API.Models;

namespace GOW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoesController : ControllerBase
    {
        private readonly gowContext _context;

        public JogoesController(gowContext context)
        {
            _context = context;
        }

        // GET: api/Jogoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
        {
          if (_context.Jogos == null)
          {
              return NotFound();
          }
            return await _context.Jogos.ToListAsync();
        }

        // GET: api/Jogoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> GetJogo(int id)
        {
          if (_context.Jogos == null)
          {
              return NotFound();
          }
            var jogo = await _context.Jogos.FindAsync(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return jogo;
        }

        // PUT: api/Jogoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogo(int id, Jogo jogo)
        {
            if (id != jogo.Id)
            {
                return BadRequest();
            }

            _context.Entry(jogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogoExists(id))
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

        // POST: api/Jogoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jogo>> PostJogo(Jogo jogo)
        {
          if (_context.Jogos == null)
          {
              return Problem("Entity set 'gowContext.Jogos'  is null.");
          }
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = jogo.Id }, jogo);
        }

        // DELETE: api/Jogoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogo(int id)
        {
            if (_context.Jogos == null)
            {
                return NotFound();
            }
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogoExists(int id)
        {
            return (_context.Jogos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
