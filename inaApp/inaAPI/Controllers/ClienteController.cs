using inaApp.Common.Interfaces;
using inaApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inaAPI.Controllers
{
    [ApiController]
    //No se toma en cuenta el nombre completo del controlador,
    //solo la parte antes de "Controller"
    [Route("api/[controller]")]

    public class ClienteController : Controller
    {
        //inyeccion de dependencias o instancia y utilizar el constructor
        public readonly IGenericService<Cliente> _clienteService;

        //se pasa la inyeccion dependencia por el constructor
        public ClienteController(IGenericService<Cliente> clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
       
        public ActionResult Index()
        {
            _clienteService.ObtenerTodosAsync();
            return Ok("Se logro");
        }//end method getAll

        
        public ActionResult Details(int id)
        {
            return View();
        }//end method getById

        
        public ActionResult Create()
        {
            return View();
        }//end method create

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }//end method create post

      
        public ActionResult Edit(int id)
        {
            return View();
        }//end method edit

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }//end method edit post

      
        public ActionResult Delete(int id)
        {
            return View();
        }//end method delete

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }//end method delete post


    }//end class
}// end namespace
