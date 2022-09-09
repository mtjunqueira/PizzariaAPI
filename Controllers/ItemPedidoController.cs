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
    public class ItemPedidoController : ControllerBase
    {
        private readonly PizzariaContext _context;

        public ItemPedidoController(PizzariaContext context)
        {
            _context = context;
        }

        // GET: api/ItemPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItemPedidos()
        {
            return await _context.ItemPedidos.ToListAsync();
        }

        // GET: api/ItemPedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetItemPedido(int id)
        {
            var itemPedido = await _context.ItemPedidos.FindAsync(id);

            if (itemPedido == null)
            {
                return NotFound();
            }

            return itemPedido;
        }

        // PUT: api/ItemPedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPedido(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPedidoExists(id))
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

        // POST: api/ItemPedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPedido>> PostItemPedido(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPedido", new { id = itemPedido.Id }, itemPedido);
        }

        // DELETE: api/ItemPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido(int id)
        {
            var itemPedido = await _context.ItemPedidos.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            _context.ItemPedidos.Remove(itemPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItemPedidos.Any(e => e.Id == id);
        }
    }
}
