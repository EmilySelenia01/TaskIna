using inaApp.Common.Exception;
using inaApp.Common.Interfaces;
using inaApp.DTOs.Producto;
using inaApp.Entities;
using inaApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace inaAPI.Controllers
{
    //RUTA DE MI CONTROLLER API 
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        //injects of dependency O INSTANCIA Y UTILIZAR EL CONSTRUCTOR 
        //PARA PASARLE LA INYECCION Y SETEARLE 
        private readonly IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> _productoService;

        //ahora paso la inyeccion dependencia por el constructor inicializa los datos, 
        public ProductoController(IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> productoService) {
          
            _productoService = productoService;//injects the service into the controller

        }//end method constructor


        //subroute for getById
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id) {

            try {
                var product = await _productoService.ObtenerPorIdAsync(id);
                return Ok(product);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (Exception ex) {
                return BadRequest($"Error al crear el producto: {ex.Message}");

            }

        }//end METHOD getById


        //status code es lo que se devuelve con ACTIONRESULT 
        [HttpGet("getAll")]
        public async Task<ActionResult>Index() {

            try {
                var lista = await _productoService.ObtenerTodosAsync();
                return Ok(lista);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (Exception ex) {
                return BadRequest($"Error al obtener los productos: {ex.Message}");
            }

        }//end METHOD getAll


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductoCreateDTO productoDTO) {

            try {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productoService.CrearAsync(productoDTO);
                return Created("Producto creado ", response);

            } catch (DuplicateNameException ex) {
                return Conflict(ex.Message);

            } catch (InvalidPriceException ex) {
                return BadRequest(ex.Message);

            } catch (InvalidStockException ex) {
                return BadRequest(ex.Message);

            } catch (Exception ex) {
                return BadRequest($"Error al crear el producto: {ex.Message}");
            }

        }//end METHOD create


        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ProductoUpdateDTO productoDTO) {
            
            try {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productoService.ActualizarAsync(productoDTO);
                return Ok(response);

            } catch (DuplicateNameException ex) {
                return Conflict(ex.Message);

            } catch (InvalidPriceException ex) {
                return BadRequest(ex.Message);

            } catch (InvalidStockException ex) {
                return BadRequest(ex.Message);

            } catch (Exception ex) {
                return BadRequest($"Error al crear el producto: {ex.Message}");
            }

        }//end METHOD edit


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            
            try {
                if (id <= 0)
                    return BadRequest("Error al eliminar, id incorrecto");

                var response = await _productoService.EliminarAsync(id);
                return response.Data ? Ok(response) : BadRequest(response);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (Exception ex) {
                return StatusCode(500, $"Error al eliminar el producto: {ex.Message}");
            }

        }//end METHOD delete


    }//end CLASS

}//end NAMESPACE
