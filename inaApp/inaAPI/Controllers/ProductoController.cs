using inaApp.Common.Interfaces;
using inaApp.Entities;
using inaApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace inaAPI.Controllers
{
    //RUTA DE MI CONTROLLER API 
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : Controller
    {
        //injects of dependency O INSTANCIA Y UTILIZAR EL CONSTRUCTOR 
        //PARA PASARLE LA INYECCION Y SETEARLE 
        private readonly IGenericService<Producto> _productoService;

        //ahora paso la inyeccion dependencia por el constructor inicializa los datos, 
        public ProductoController(IGenericService<Producto> productoService) {
            
            //injects the service into the controller
            _productoService = productoService;

        }//end method constructor


        //status code es lo que se devuelve con ACTIONRESULT 
        [HttpGet("getAll")]
        public async Task<ActionResult>Index() {
            var lista = await _productoService.ObtenerTodosAsync();
            
            if (lista.Count == 0)
                return NotFound("No hay datos");
            
            return Ok(lista);

        }//end method getAll


        //subroute for getById
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id) {
            if (id <= 0)
                return BadRequest("Id incorrecto");

            var product = await _productoService.ObtenerPorIdAsync(id);
            return Ok(product);

        }//end method getById


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Producto producto) {
            
            try {
                var result = await _productoService.CrearAsync(producto);
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Error al crear el producto: {ex.Message}");
            }

        }//end method create

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Producto producto)
        {
            producto.Id = id; // assure that the ID from the route is used

            if (id <= 0)
                return BadRequest("Id incorrecto");

            var result = await _productoService.ActualizarAsync(producto);
            return Ok(result);

        }//end method edit


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            
            if (id <= 0)
                return BadRequest("Error al eliminar, id incorrecto");
            
            var result = await _productoService.EliminarAsync(id);
            
            return result? Ok("Producto eliminado correctamente") : NotFound("Producto no encontrado");

        }//end method delete

    }//end class
}//end namespace
