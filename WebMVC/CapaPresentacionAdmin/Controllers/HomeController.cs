using CapaPresentacionAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CapaEntidad.Entities;
using CapaNegocio;


namespace CapaPresentacionAdmin.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CN_Usuarios _cnUsuarios;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(ILogger<HomeController> logger, CN_Usuarios cnUsuarios, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _cnUsuarios = cnUsuarios;
            _serviceProvider = serviceProvider;
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

            List<Usuario> oLista = _cnUsuarios.Listar();
            var resultado = new
            {
                data = oLista,
                recordsTotal = oLista.Count
            };

            return new JsonResult( resultado);
        }


        /// <summary>
        /// Clase para auxiliarme la obtencion de informacion desde el cliente, ya que no se puede deserealizar automaticamente de string a Guid, y todas mis clases tienen un Guid Id
        /// </summary>
        public class CrearEditarUsuarioModel
        {
            public string id { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string correo { get; set; }
            public bool activo { get; set; }
        }

        [HttpPost]
        public JsonResult GuardarUsuario( [FromBody] CrearEditarUsuarioModel obj)
        {
            var usuario = new Usuario();
            Console.WriteLine(obj.id);

            if (Guid.TryParse(obj.id.Trim(), out Guid guidId) || guidId == Guid.Empty)
            {
                usuario.Id = guidId;
            }
            else
            {
                // Maneja el caso donde obj.Id no es un GUID válido
                throw new ArgumentException("Formato GUID inválido", nameof(obj));
            }

            usuario.Nombre = obj.nombre;
            usuario.Apellidos = obj.apellidos;
            usuario.Correo = obj.correo;
            usuario.Activo = obj.activo;

            Console.WriteLine(guidId);
            object resultado="123";
            string mensaje = string.Empty;
            using var scope = _serviceProvider.CreateScope();
            var cnUsuarios = scope.ServiceProvider.GetService<CN_Usuarios>();

            if (usuario.Id == Guid.Empty)
            {
                resultado = cnUsuarios.Registrar(usuario, out mensaje);
            }
            else
            {
                resultado = cnUsuarios.Editar(usuario, out mensaje);
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
