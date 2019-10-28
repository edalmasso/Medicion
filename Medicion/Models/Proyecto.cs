using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Models
{
    public class Proyecto
    {
        public int Id { get; set; }

        public int ContratoId { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public string Estudio { get; set; }

        public DateTime FechaCreado { get; set; }

        public DateTime? FechaBaja { get; set; }

        #region Navegación
        public Contrato Contrato { get; set; }

        public IEnumerable<PuntoEstudio> PuntoEstudios { get; set; }
        #endregion
    }
}
