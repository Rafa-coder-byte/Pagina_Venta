using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entities;
using Contracts;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private readonly IUsuarioRepository _objCapaDato; // Cambiamos el nombre para seguir la convención de campos privados

        // Inyectamos la dependencia a través del constructor
        public CN_Usuarios(IUsuarioRepository objCapaDato)
        {
            _objCapaDato = objCapaDato;
        }

        public List<Usuario> Listar()
        {
            return _objCapaDato.Listar();
        }
    }
}
