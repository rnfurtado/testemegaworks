using Api.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : Controller
    {
        // GET: api/ContaBancaria/GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaBancaria>>> GetAll()
        {
            MegaworksContext _context = new MegaworksContext();

            return await _context.ContaBancaria.ToListAsync();
        }

        // GET: api/ContaBancaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaBancaria>> GetById(int id)
        {
            MegaworksContext _context = new MegaworksContext();

            var pagamento = await _context.ContaBancaria.FindAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        // PUT: api/ContaBancaria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContaBancaria conta)
        {
            MegaworksContext _context = new MegaworksContext();

            if (id != conta.ContaId)
            {
                return BadRequest();
            }

            _context.Entry(conta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Pagamentos
        [HttpPost]
        public async Task<ActionResult<ContaBancaria>> Insert([FromBody] ContaBancaria conta)
        {
            MegaworksContext _context = new MegaworksContext();

            _context.ContaBancaria.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = conta.ContaId }, conta);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaBancaria>> Delete(int id)
        {
            MegaworksContext _context = new MegaworksContext();

           var conta = await _context.ContaBancaria.FindAsync(id);

            if (conta == null)
            {
                return NotFound();
            }

            _context.ContaBancaria.Remove(conta);
            await _context.SaveChangesAsync();

            return conta;
        }
    }
}
