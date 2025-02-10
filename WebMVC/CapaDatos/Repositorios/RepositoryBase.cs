using CapaEntidad.Common;
using CapaEntidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        public virtual List<T> Listar() {  return new List<T>(); }
        public abstract Guid Registrar(T obj, out string Mensaje);
        public abstract bool Editar(T obj, out string Mensaje);
        public abstract bool Eliminar(Guid Id, out string mensaje);

    }
}
