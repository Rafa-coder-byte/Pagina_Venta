using CapaPresentacionAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CapaEntidad.Entities;
using CapaNegocio;
using System.Text.Json;  // Make sure to include this
using System.Text.Json.Serialization; // And this
//using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CN_Usuarios _cnUsuarios;

        public HomeController(ILogger<HomeController> logger, CN_Usuarios cnUsuarios)
        {
            _logger = logger;
            _cnUsuarios = cnUsuarios;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public JsonResult ListarUsuarios() {

            // Usar la instancia inyectada a través del constructor
            List<Usuario> oLista = _cnUsuarios.Listar();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Ignora si las letras son mayúsculas o minúsculas
                ReferenceHandler = ReferenceHandler.Preserve, // Para manejar referencias circulares
                WriteIndented = true // ¡Esto es lo que hace la magia!
            };

            return new JsonResult(oLista, options);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
