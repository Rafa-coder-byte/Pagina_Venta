using CapaEntidad.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using Contracts;

namespace CapaDatos.Repositorios
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly IConnectionFactory _connection;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }

        //Metodo que me va a devolver una lista de todos los usuarios
        public override List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = _connection.CreateConnection())
                {
                    Console.WriteLine("Se conecto");

                    // Aquí puedes agregar la consulta SQL para obtener los usuarios
                    string query = "select Id,Nombre,Apellidos,Correo,Clave,Reestablecer,Activo from USUARIO";

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
    }
}
