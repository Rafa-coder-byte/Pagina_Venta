using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad.Entities
{
    public class Cliente : Entity
    {

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Reestablecer { get; set; }

        public Cliente() { }

        public Cliente(Guid id, string nombre, string apellidos, string correo, string clave, bool reestablecer) : base(id)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Correo = correo;
            Clave = clave;
            Reestablecer = reestablecer;
        }
    }
}
