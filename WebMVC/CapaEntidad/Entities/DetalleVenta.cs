using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Entities
{
    public class DetalleVenta : Entity
    {
        public int IdVenta { get; set; }
        public Producto oProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalDecimal { get; set; }
        public string IdTransaccion { get; set; } //Me lo da Paypal para poder Generar el pago

        public DetalleVenta() { }

        public DetalleVenta(int id, int idVenta, Producto producto, int cantidad, decimal totalDecimal) : base(id)
        {
            IdVenta = idVenta;
            oProducto = producto;
            Cantidad = cantidad;
            TotalDecimal = totalDecimal;
        }
    }
}
