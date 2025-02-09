using CapaEntidad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CapaEntidad
{
    public class DirCliente : ValueObject
    {
        public string IdDirCliente { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }

        public DirCliente() { }

        public DirCliente(string idDirCliente, string pais, string provincia, string distrito, string direccion)
        {
            IdDirCliente = idDirCliente;
            Pais = pais;
            Provincia = provincia;
            Distrito = distrito;
            Direccion = direccion;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IdDirCliente;
            yield return Pais;
            yield return Provincia;
            yield return Distrito;
            yield return Direccion;
        }
    }
}
