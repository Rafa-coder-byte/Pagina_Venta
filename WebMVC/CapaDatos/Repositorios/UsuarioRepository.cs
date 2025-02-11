using CapaEntidad.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using ContractsDatos;


namespace CapaDatos.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connection;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }

        //Metodo que me va a devolver una lista de todos los usuarios
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = _connection.CreateConnection())
                {
                    Console.WriteLine("Se conecto");

                    // Aquí puedes agregar la consulta SQL para obtener los usuarios
                    string query = "select Id,Nombre,Apellidos,Correo,Clave,Activo,Reestablecer from USUARIO";

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
                            Id = reader.GetGuid(0),
                            Nombre = reader.GetString(1),
                            Apellidos = reader.GetString(2),
                            Correo = reader.GetString(3),
                            Clave = reader.GetString(4),
                            Activo = reader.GetBoolean(5),
                            Reestablecer = reader.GetBoolean(6)
                        };
                        Console.WriteLine("Va a Agrear Usuario");
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



        public Guid Registrar(Usuario obj, out string Mensaje)
        {
            Guid IdAutogenerado = Guid.Empty;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = _connection.CreateConnection())
                {


                    using (SqlCommand comando = new SqlCommand("sp_RegistrarUsuario", oconexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenado.
                        comando.Parameters.AddWithValue("@nombre", obj.Nombre);
                        comando.Parameters.AddWithValue("@apellidos", obj.Apellidos);
                        comando.Parameters.AddWithValue("@correo", obj.Correo);
                        comando.Parameters.AddWithValue("@clave", obj.Clave);
                        comando.Parameters.AddWithValue("@activo", obj.Activo);

                        // Parámetros de salida.
                        SqlParameter mensajeParametro = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 500)
                        { Direction = ParameterDirection.Output };

                        SqlParameter resultadoParametro = new SqlParameter("@Resultado", SqlDbType.UniqueIdentifier)
                        { Direction = ParameterDirection.Output };

                        // Agregar parámetros a la consulta.
                        comando.Parameters.Add(mensajeParametro);
                        comando.Parameters.Add(resultadoParametro);
                     



                        oconexion.Open();

                        // Ejecutar el procedimiento y obtener resultados:
                        comando.ExecuteNonQuery();

                        if (mensajeParametro.Value != DBNull.Value)
                        {
                            Mensaje = mensajeParametro.Value.ToString();
                        }
                        else
                        {
                            Mensaje = string.Empty; // O cualquier otro valor por defecto que desees.
                        }
                        IdAutogenerado = (Guid)resultadoParametro.Value;
                

                    }
                }
            }

            catch (Exception ex)
            {
                IdAutogenerado = Guid.Empty;
                Mensaje = ex.Message;
            }

            return IdAutogenerado;
        }




        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = _connection.CreateConnection())
                {


                    using (SqlCommand comando = new SqlCommand("sp_EditarUsuario", oconexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenado.
                        comando.Parameters.AddWithValue("@id", obj.Id);
                        comando.Parameters.AddWithValue("@nombre", obj.Nombre);
                        comando.Parameters.AddWithValue("@apellidos", obj.Apellidos);
                        comando.Parameters.AddWithValue("@correo", obj.Correo);
                        comando.Parameters.AddWithValue("@clave", obj.Clave);
                        comando.Parameters.AddWithValue("@activo", obj.Activo);

                        // Parámetros de salida.
                        SqlParameter mensajeParametro = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 500)
                        { Direction = ParameterDirection.Output };

                        SqlParameter resultadoParametro = new SqlParameter("@Resultado", SqlDbType.Bit)
                        { Direction = ParameterDirection.Output };

                        // Agregar parámetros a la consulta.
                        comando.Parameters.Add(mensajeParametro);
                        comando.Parameters.Add(resultadoParametro);
                       



                        oconexion.Open();

                        // Ejecutar el procedimiento y obtener resultados:
                        comando.ExecuteNonQuery();

                        resultado = (bool)resultadoParametro.Value;
                        Mensaje = (string)mensajeParametro.Value;

                    }
                }
            }

            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }

            return resultado;
        }

        public bool Eliminar(Guid Id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = _connection.CreateConnection())
                {


                    using (SqlCommand comando = new SqlCommand("delete top (1) from usuario where id = @Id", oconexion))
                    {

                        comando.Parameters.AddWithValue("@id", Id);
                        comando.CommandType = CommandType.Text;

                        oconexion.Open();

                        // Ejecutar el procedimiento y obtener resultados:
                        comando.ExecuteNonQuery();

                        resultado = comando.ExecuteNonQuery() > 0 ? true : false;

                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;
        }
    }
}





