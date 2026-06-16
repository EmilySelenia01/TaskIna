using Azure;
using inaApp.Common.Exception;
using inaApp.Common.Interfaces;
using inaApp.DTOs.Cliente;
using inaApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inaAPI.Controllers
{
    //No se toma en cuenta el nombre completo del controlador,
    //solo la parte antes de "Controller"
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller {
        
        //inject of dependency the interface of service
        public readonly IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO> _clienteService;

        //it goes through for parameter the interface of service 
        public ClienteController(IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO> clienteService) {

            _clienteService = clienteService;
        }//end method constructor

        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id) {

            try {
                var client = await _clienteService.ObtenerPorIdAsync(id);
                return Ok(client);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);
            } catch (InvalidIdException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return BadRequest($"Error al obtener el cliente: {ex.Message}");
            }

        }//end METHOD getById


        [HttpGet]
        public async Task<ActionResult> Index() {
            
            try {
                var list = await _clienteService.ObtenerTodosAsync();
                return Ok(list);

            } catch (NotFoundExceptionD ex) {
                return NotFound(new {mensaje = ex.Message });
            } catch (Exception ex) {
                return BadRequest(new { mensaje = $"Error al obtener los clientes: {ex.Message}" });
            }

        }//end METHOD Index

   

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClienteCreateDTO clienteDTO) {
            
            try {
                var client = await _clienteService.CrearAsync(clienteDTO);
                return Created("Cliente creado ", client);

            } catch (InvalidExceptionData ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return BadRequest($"Error al crear los cliente: {ex.Message}");
            }

        }//end METHOD create


        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ClienteUpdateDTO clienteDTO) {
            
            try {
                var client = await _clienteService.ActualizarAsync(clienteDTO);
                return Ok(client);

            }
            catch (InvalidExceptionData ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return BadRequest($"Error al actualizar el cliente: {ex.Message}");
            }

        }//end METHOD update


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            
            try {
                var client = await _clienteService.EliminarAsync(id);
                return Ok(client);

            } catch (NotFoundExceptionD ex) {
                return NotFound(ex.Message);
            } catch (InvalidIdException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return BadRequest($"Error al eliminar al cliente: {ex.Message}");
            }

        }//end METHOD delete


    }//end class

}// end namespace
