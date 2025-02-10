using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaEntidad.Entities
{
    public class Producto : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca oMarca { get; set; }
        public Categoria oCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; }

        public Producto() { }

        public Producto(Guid id, string nombre, string descripcion, Marca marca, Categoria categoria, decimal precio, int stock, string rutaImagen, string nombreImagen, bool activo) : base(id)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            oMarca = marca;
            oCategoria = categoria;
            Precio = precio;
            Stock = stock;
            RutaImagen = rutaImagen;
            NombreImagen = nombreImagen;
            Activo = activo;
        }
    }
}
