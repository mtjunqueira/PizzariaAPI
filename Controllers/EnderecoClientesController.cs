using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoClientesController : ControllerBase
    {
        private readonly PizzariaContext _context;

        public EnderecoClientesController(PizzariaContext context)
        {
            _context = context;
        }

        // GET: api/EnderecoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoCliente>>> GetEnderecoClientes()
        {
            return await _context.EnderecoClientes.ToListAsync();
        }

        // GET: api/EnderecoClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoCliente>> GetEnderecoCliente(int id)
        {
            var enderecoCliente = await _context.EnderecoClientes.FindAsync(id);

            if (enderecoCliente == null)
            {
                return NotFound();
            }

            return enderecoCliente;
        }

        // PUT: api/EnderecoClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoCliente(int id, EnderecoCliente enderecoCliente)
        {
            if (id != enderecoCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(enderecoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoClienteExists(id))
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

        // POST: api/EnderecoClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoCliente>> PostEnderecoCliente(EnderecoCliente enderecoCliente)
        {
            _context.EnderecoClientes.Add(enderecoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoCliente", new { id = enderecoCliente.Id }, enderecoCliente);
        }

        // DELETE: api/EnderecoClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoCliente(int id)
        {
            var enderecoCliente = await _context.EnderecoClientes.FindAsync(id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }

            _context.EnderecoClientes.Remove(enderecoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoClienteExists(int id)
        {
            return _context.EnderecoClientes.Any(e => e.Id == id);
        }
    }
}
