using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Models
{
    public class DatosPunto
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int Valor { get; set; }

        public int PuntoEstudioId { get; set; }

        #region Navegacion
        public PuntoEstudio PuntoEstudio { get; set; }
        #endregion
    }
}
