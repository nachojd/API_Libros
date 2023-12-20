using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Libros.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Libros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DblibroContext _dblibroContext;

        public LibroController(DblibroContext dblibroContext)
        {
            _dblibroContext = dblibroContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task <IActionResult> Lista()
        {
            // Nos traemos la lista de libros
            var listaLibros = await _dblibroContext.Libros.ToListAsync();
            return Ok(listaLibros);
        }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody]Libro request)
        {
            await _dblibroContext.Libros.AddAsync(request);
            await _dblibroContext.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var libroEliminar = await _dblibroContext.Libros.FindAsync(id);

            if (libroEliminar == null)       
                return BadRequest("El libro no existe");
            _dblibroContext.Libros.Remove(libroEliminar);
            await _dblibroContext.SaveChangesAsync();
            return Ok(libroEliminar);

            
        }
    }
}
