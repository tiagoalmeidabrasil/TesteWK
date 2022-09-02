using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoWK.Model;

namespace TesteTecnicoWK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategoria()
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }

            return await _context.Categoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> GetCategorias(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }
            var categorias = await _context.Categoria.FindAsync(id);

            if (categorias == null)
            {
                return NotFound();
            }

            return categorias;
        }

        [HttpPut]
        public async Task<ActionResult<Categorias>> PutCategorias(Categorias categorias)
        {
            _context.Entry(categorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasExists(categorias.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PutCategorias", new { id = categorias.Id }, categorias);
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> PostCategorias(Categorias categorias)
        {
            if (_context.Categoria == null)
            {
                return Problem("Entity set 'AppDbContext.Categoria'  is null.");
            }
            _context.Categoria.Add(categorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorias", new { id = categorias.Id }, categorias);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorias(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }
            var categorias = await _context.Categoria.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriasExists(int id)
        {
            return (_context.Categoria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
