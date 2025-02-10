using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Entities
{

   
    public class Categoria : Entity
    {

        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public Categoria() { }

        public Categoria(Guid id, string descripcion, bool activo) : base(id)
        {
            Descripcion = descripcion;
            Activo = activo;
        }


    }
}
