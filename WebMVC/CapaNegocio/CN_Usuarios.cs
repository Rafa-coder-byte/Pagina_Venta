using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Repositorios;
using CapaEntidad.Entities;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private UsuarioRepository objCapaDato = new UsuarioRepository();


        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }



    }
}
