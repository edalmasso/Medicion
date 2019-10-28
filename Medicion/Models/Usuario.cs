using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Models
{
    public class Usuario : IdentityUser<int>
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string DocumentoTipo { get; set; }

        public string DocumentoNumero { get; set; }

        public int EmpresaId { get; set; }

        #region Navegación
        public Empresa Empresa { get; set; }
        #endregion
    }
}
