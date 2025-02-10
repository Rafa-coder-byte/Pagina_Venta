using CapaPresentacionAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CapaEntidad.Entities;
using CapaNegocio;
using System.Text.Json;
using System.Text.Json.Serialization;


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

        [HttpGet]
        public JsonResult ListarUsuarios()
        {

            // Usar la instancia inyectada a través del constructor
            List<Usuario> oLista = _cnUsuarios.Listar();
            var resultado = new
            {
                data = oLista,
                recordsTotal = oLista.Count
            };

            return new JsonResult( resultado);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.Id == Guid.Empty)
            {
                resultado = new CN_Usuarios().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Usuarios().Editar(objeto, out mensaje);   
            }

            return new JsonResult(new { resultado = resultado, mensaje = mensaje });
        }


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
