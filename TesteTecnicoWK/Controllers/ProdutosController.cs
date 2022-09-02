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
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            //return await _context.Produtos.Include(p => p.Categorias).ToListAsync();// 
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProdutos(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos.FindAsync(id);
            //var produtos = await _context.Produtos.Include(p => p.Categorias).FirstOrDefaultAsync(m => m.Id == id);

            if (produtos == null)
            {
                return NotFound();
            }

            return produtos;
        }

        [HttpPut]
        public async Task<ActionResult<Produtos>> PutProdutos(Produtos produtos)
        {
            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(produtos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PutProdutos", new { id = produtos.Id }, produtos);
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> PostProdutos(Produtos produtos)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'AppDbContext.Produtos'  is null.");
            }
            _context.Produtos.Add(produtos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutos", new { id = produtos.Id }, produtos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutos(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
