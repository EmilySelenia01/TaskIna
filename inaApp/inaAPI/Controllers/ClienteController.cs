using inaApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inaAPI.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        //inyeccion de dependencias o instancia y utilizar el constructor
        public readonly IClienteService _clienteService;

        //se pasa la inyeccion dependencia por el constructor
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        // GET: ClienteController
        public ActionResult Index()
        {
            _clienteService.ObtenerTodosAsync();
            return Ok("Se logro");
        }//end method getAll

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }//end method getById

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }//end method create

        // POST: ClienteController/Create
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }//end method edit

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }//end method delete

        // POST: ClienteController/Delete/5
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
