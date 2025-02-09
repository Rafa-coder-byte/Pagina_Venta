using CapaEntidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using CapaDatos.Utilities;

namespace CapaDatos.Repositorios
{
    public class UsuarioRepository
    {
        //Metodo que me va a devolver una lista de todos los usuarios
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection oconexion = conexion.ObtenerConexion())
                {


                    // Aquí puedes agregar la consulta SQL para obtener los usuarios
                    string query = "select Id,Nombre,Apellidos,Correo,Clave,Reestablecer,Activo * from USUARIO";

                    SqlCommand comando = new SqlCommand(query, oconexion);
                    comando.CommandType = CommandType.Text;

                    oconexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            // Aquí puedes agregar las propiedades del objeto Usuario
                            // que corresponden a las columnas de la tabla Usuarios
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellidos = reader.GetString(2),
                            Correo = reader.GetString(3),
                            Clave = reader.GetString(4),
                            Activo = reader.GetBoolean(5),
                            Reestablecer = reader.GetBoolean(6)
                        };

                        lista.Add(usuario);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                lista = new List<Usuario>();
            }

            return lista;
        }
    }
}
