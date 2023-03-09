using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapp_aylin.Entidades;
using System.Threading.Tasks;
using System.Linq;

namespace webapp_aylin.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public ClienteController(AplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return await dbContext.Cliente.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = dbContext.Cliente.FirstOrDefault(x => x.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            
            dbContext.Add(cliente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Cliente cliente, int id)
        {
            var exist = await dbContext.Cliente.AnyAsync(x => x.IdCliente == id);
            if (!exist) 
            {
                return NotFound("El cliente no existe");
            }
            if (cliente.IdCliente != id) 
            {
                return BadRequest("El id no coincide con el establecido");
            }
            dbContext.Update(cliente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(Cliente cliente, int id)
        {
            var exist = await dbContext.Cliente.AnyAsync(x => x.IdCliente == id);
            if (!exist)
            {
               return NotFound("No se encontro. ");
            }
            dbContext.Remove(new Cliente { IdCliente = id});
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

