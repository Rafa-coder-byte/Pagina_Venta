using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaEntidad.Entities
{

    public class Usuario : Entity
    { 
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public bool Reestablecer { get; set; }

        public Usuario() { }

        public Usuario(Guid id, string nombre, string apellidos, string correo, string clave, bool activo, bool reestablecer) : base(id)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Correo = correo;
            Clave = clave;
            Activo = activo;
            Reestablecer = reestablecer;
        }
    }
}
