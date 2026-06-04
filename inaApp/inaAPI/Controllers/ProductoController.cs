using inaApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inaAPI.Controllers
{
    //RUTA DE MI CONTROLLER API 
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : Controller
    {
        //INYECCION DE DEPENDENCIAS O INSTANCIA Y UTILIZAR EL CONSTRUCTOR 
        //PARA PASARLE LA INYECCION Y SETEARLE 

        private readonly IProductoService _productoService;

        //ahora paso la inyeccion dependencia por el constructor 
        //inicializa los datos, 
        public ProductoController(IProductoService productoService)
        {
            //inyecta el servio en el controlador 
            _productoService = productoService;
        }
        
        // GET: ProductoController
        //status code es lo que se devuelve con ACTIONRESULT 
        [HttpGet]
        public ActionResult Index()
        {
            _productoService.ObtenerTodosAsync();

            return Ok("Correcto");
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
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
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
        }
    }
}
