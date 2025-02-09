using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Entities
{
    public class Venta : Entity
    {
        public int IdCliente { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string IdTransaccion { get; set; } //Me lo da Paypal para podewr realizar el pago
        public string RutaImagen { get; set; }
        public DateTime FechaVenta { get; set; }
        public List<DetalleVenta> oDetalleVentas { get; set; }

        public Venta() { }

        public Venta(int id, int idCliente, int totalProducto, decimal montoTotal, string contacto, string telefono, string direccion, string idTransaccion, string rutaImagen, DateTime fechaVenta) : base(id)
        {
            IdCliente = idCliente;
            TotalProducto = totalProducto;
            MontoTotal = montoTotal;
            Contacto = contacto;
            Telefono = telefono;
            Direccion = direccion;
            IdTransaccion = idTransaccion;
            RutaImagen = rutaImagen;
            FechaVenta = fechaVenta;
        }
    }
}
