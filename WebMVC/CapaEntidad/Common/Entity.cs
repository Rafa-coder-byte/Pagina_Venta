

namespace CapaEntidad.Common
{
    public abstract class Entity
    {
        #region Properties

        public Guid Id { get; set; } // Propiedad para identificar de manera única a la entidad.

        #endregion

        public Entity() { } // Constructor por defecto.

        public Entity(Guid id) // Constructor que permite establecer el ID al crear una entidad.
        {
            Id = id; // Asigna el ID recibido a la propiedad Id.
        }
    }
}

