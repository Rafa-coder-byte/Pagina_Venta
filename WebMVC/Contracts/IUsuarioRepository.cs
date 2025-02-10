using CapaEntidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        public Guid Registrar(Usuario obj, out string Mensaje);
        public bool Editar(Usuario obj, out string Mensaje);
        public bool Eliminar(Guid Id, out string mensaje);
    }
}
