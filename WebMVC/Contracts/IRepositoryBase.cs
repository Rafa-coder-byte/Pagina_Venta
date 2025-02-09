using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : Entity
    {
        public List<T> Listar();
    }
}
