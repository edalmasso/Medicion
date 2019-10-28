using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Models
{
    public class PuntoEstudio
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Localidad { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public DateTime FechaCreado { get; set; }

        public DateTime? FechaBaja { get; set; }

        #region Datos de configuración
        public int Pozo_Profundidad { get; set; }

        public int Pozo_Diametro { get; set; }

        public int Punzado_Largo { get; set; }

        public int Punzado_Diametro { get; set; }

        public int Temp_Pozo { get; set; }

        public int DensidadRoca { get; set; }

        public int Saturacion { get; set; }

        public int Presion { get; set; }

        public int DensidadFluido { get; set; }

        /// Continuar...
        #endregion

        #region Navegación
        public Proyecto Proyecto { get; set; }

        public IEnumerable<DatosPunto> Datos { get; set; }
        #endregion
    }
}
