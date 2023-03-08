using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp_aylin.Entidades;

namespace webapp_aylin.Controllers
{
    //Componentes
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        public ProductoController(AplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetAll()
        {
            return await dbContext.Producto.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Producto> Get(int id)
        {
            var prod = dbContext.Producto.FirstOrDefault(x => x.IdProducto == id);
            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Producto prod)
        {
            dbContext.Add(prod);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Producto prod, int id)
        {
            var exist = await dbContext.Producto.AnyAsync(x => x.IdProducto == id);
            if (!exist)
            {
                return NotFound("El producto no existe");
            }
            if (prod.IdProducto != id)
            {
                return BadRequest("El id no coincide con el establecido");
            }
            dbContext.Update(prod);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(Producto prod, int id)
        {
            var exist = await dbContext.Producto.AnyAsync(x => x.IdProducto == id);
            if (!exist)
            {
                return NotFound("No se encontro. ");
            }
            dbContext.Remove(new Producto { IdProducto = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

