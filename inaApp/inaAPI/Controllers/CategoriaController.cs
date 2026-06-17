using inaApp.Common.Exception;
using inaApp.Common.Interfaces;
using inaApp.DTOs.Categoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {

        private readonly IGenericService<CategoriaResponseDTO, CategoriaCreateDTO, CategoriaUpdateDTO> _categoriaService; 

        public CategoriaController(IGenericService<CategoriaResponseDTO, CategoriaCreateDTO, CategoriaUpdateDTO> categoriaService) {
            _categoriaService = categoriaService;
        }

        [HttpGet("{id}")]
        // GET: CategoriaController/Details/5
        public async Task<ActionResult> Details(int id) {

            try {
                var category = await _categoriaService.ObtenerPorIdAsync(id);
                return Ok(category);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (InvalidIdException ex) {
                return BadRequest(ex.Message);

            } catch (Exception ex) {
                return BadRequest(new { mensaje = $"Error al obtener la categoria: {ex.Message}" });
            }

        }//end METHOD


        [HttpGet]
        public async Task<ActionResult> Index() {
            
            try {
                var list = await _categoriaService.ObtenerTodosAsync();
                return Ok(list);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (Exception ex) {
                return BadRequest(new { mensaje = $"Error al obtener las categorias: {ex.Message}" });
            }

        }//end METHOD


        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CategoriaCreateDTO createDTO) {
            try {
                var categoria = await _categoriaService.CrearAsync(createDTO);
                return Created("Categoria creada: ", categoria );

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (DuplicateNameException ex) {
                return BadRequest(ex.Message);

            } catch (Exception ex) {
                return BadRequest(new { mensaje = $"Error al obtener las categorias: {ex.Message}" });
            }

        }//end METHOD


        [HttpPut]
        // GET: CategoriaController/Edit/5
        public async Task<ActionResult> Edit([FromBody] CategoriaUpdateDTO updateDTO) {

            try {
                var categoria = await _categoriaService.ActualizarAsync(updateDTO);
                return Ok(categoria);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (DuplicateNameException ex) {
                return BadRequest(ex.Message);

            } catch (Exception ex) {
                return BadRequest(new { mensaje = $"Error al obtener las categorias: {ex.Message}" });
            }
           
        }//end METHOD


        [HttpDelete("{id}")]
        // GET: CategoriaController/Delete/5
        public async Task<ActionResult> Delete(int id) { 
            
            try {
                var categoryDelete = await _categoriaService.EliminarAsync(id);
                return Ok(categoryDelete);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);

            } catch (InvalidIdException ex) {
                return BadRequest(ex.Message);

            } catch (Exception ex) {
                return BadRequest(new { mensaje = $"Error al obtener la categoria: {ex.Message}" });
            }

        }//end METHOD


    }// end CLASS

}// end NAMESPACE
