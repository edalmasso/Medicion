using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int EmpresaId { get; set; }

        public string Logo { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }

        #region Navegación
        public Empresa Empresa { get; set; }

        public IEnumerable<Proyecto> Proyectos { get; set; }
        #endregion
    }
}
