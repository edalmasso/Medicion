using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        public int Id { get; set; }

        public string CUIT { get; set; }

        public string Direccion { get; set; }
        
        public DateTime FechaCreacion { get; set; }

        public string RazonSocial { get; set; }

        public string Telefono { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public string Pais { get; set; }

        public string Logo { get; set; }

        public string Icono { get; set; }
    }
}
