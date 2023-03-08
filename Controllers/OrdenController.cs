using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapp_aylin.Entidades;
using System.Threading.Tasks;
using System.Linq;

namespace webapp_aylin.Controllers
{
    //Orden
    [ApiController]
    [Route("api/orden")]
    public class OrdenController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        public OrdenController(AplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Orden>>> GetAll()
        {
            return await dbContext.Orden.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Orden> Get(int id)
        {
            var orden = dbContext.Orden.FirstOrDefault(x => x.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }
            return orden;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Orden orden, int id, int id2)
        {
            var existeCliente = await dbContext.Cliente.AnyAsync(x => x.IdCliente == id);
            var existeProducto = await dbContext.Producto.AnyAsync(x => x.IdProducto == id2);
            if (!existeCliente)
            {
                return BadRequest($"No existe el cliente con id: {orden.IdCliente} ");
            }
            if (!existeProducto)
            {
                return BadRequest($"No existe el producto con id: {orden.IdProducto} ");
            }
            dbContext.Add(orden);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Orden orden, int id)
        {
            var exist = await dbContext.Orden.AnyAsync(x => x.IdOrden == id);
            if (!exist)
            {
                return NotFound("La orden no existe");
            }
            if (orden.IdOrden != id)
            {
                return BadRequest("El id no coincide con el establecido");
            }
            dbContext.Update(orden);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(Orden orden, int id)
        {
            var exist = await dbContext.Orden.AnyAsync(x => x.IdOrden == id);
            if (!exist)
            {
                return NotFound("No se encontro. ");
            }
            dbContext.Remove(new Orden { IdOrden = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}

