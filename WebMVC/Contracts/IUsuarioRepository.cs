using CapaEntidad.Entities;


namespace ContractsDatos
{
    public interface IUsuarioRepository 
    {
        public List<Usuario> Listar();
        public Guid Registrar(Usuario obj, out string Mensaje);
        public bool Editar(Usuario obj, out string Mensaje);
        public bool Eliminar(Guid Id, out string mensaje);
    }
}
