using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Entities
{
 
        public class Carrito : Entity
        {
            public Cliente oCliente { get; set; }
            public Producto oProducto { get; set; }
            public int Cantidad { get; set; }

            public Carrito() { }

            public Carrito(int id, Cliente cliente, Producto producto, int cantidad) : base(id)
            {
                oCliente = cliente;
                oProducto = producto;
                Cantidad = cantidad;
            }
        }  
}
