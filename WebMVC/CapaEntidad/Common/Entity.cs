using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Common
{
    public abstract class Entity
    {
        #region Properties

        public int Id { get; set; } // Propiedad para identificar de manera única a la entidad.

        #endregion

        protected Entity() { } // Constructor por defecto.

        protected Entity(int id) // Constructor que permite establecer el ID al crear una entidad.
        {
            Id = id; // Asigna el ID recibido a la propiedad Id.
        }

    }
}
