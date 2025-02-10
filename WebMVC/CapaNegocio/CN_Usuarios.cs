using System.Text.RegularExpressions;
using CapaEntidad.Entities;
using Contracts;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private readonly IUsuarioRepository _objCapaDato; // Cambiamos el nombre para seguir la convención de campos privados

        public CN_Usuarios(){}


        // Inyectamos la dependencia a través del constructor
        public CN_Usuarios(IUsuarioRepository objCapaDato)
        {
            _objCapaDato = objCapaDato;
        }

        public List<Usuario> Listar()
        {
            return _objCapaDato.Listar();
        }

        public Guid Registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validación básica
            if (obj == null)
            {
                mensaje = "El objeto usuario no puede ser nulo.";
                return Guid.Empty;
            }

            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(obj.Nombre) || string.IsNullOrEmpty(obj.Nombre))
            {
                mensaje += "El nombre es obligatorio.\n";
                return Guid.Empty;
            }

            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje += "Los apellidos son obligatorios.\n";
                return Guid.Empty;
            }

            if (string.IsNullOrWhiteSpace(obj.Clave))
            {
                mensaje += "La clave es obligatoria.\n";
                return Guid.Empty;

                // Puedes agregar más restricciones a la clave si es necesario, como longitud mínima.

                // Ejemplo:
                //if (obj.Clave.Length < 8) 
                //{
                //mensaje += "La clave debe tener al menos 8 caracteres.\n";
                //return Guid.Empty;
                //}

            }


            // Validación del formato del correo electrónico usando expresión regular

            var regexCorreo = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            if (!regexCorreo.IsMatch(obj.Correo) || string.IsNullOrEmpty(obj.Correo))
            {
                mensaje += "El formato del correo electrónico no es válido.";
                return Guid.Empty;
            }


            string clave = "text123";
            obj.Clave = CN_Recursos.ConvertirSha256(clave); 


            return _objCapaDato.Registrar(obj, out mensaje);
        }



        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validación básica
            if (obj == null)
            {
                mensaje = "El objeto usuario no puede ser nulo.";
                return false;
            }

            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(obj.Nombre) || string.IsNullOrEmpty(obj.Nombre))
            {
                mensaje += "El nombre es obligatorio.\n";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje += "Los apellidos son obligatorios.\n";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Clave))
            {
                mensaje += "La clave es obligatoria.\n";
                return false;

               

            }


            // Validación del formato del correo electrónico usando expresión regular

            var regexCorreo = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            if (!regexCorreo.IsMatch(obj.Correo) || string.IsNullOrEmpty(obj.Correo))
            {
                mensaje += "El formato del correo electrónico no es válido.";
                return false;
            }


            return _objCapaDato.Editar(obj, out mensaje);
        }


        public bool Eliminar(Guid Id, out string mensaje)
        {
            return _objCapaDato.Eliminar(Id, out mensaje);
        }

    }
}
