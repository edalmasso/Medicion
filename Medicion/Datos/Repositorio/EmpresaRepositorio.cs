using Medicion.Datos.Repositorio.Core;
using Medicion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Datos.Repositorio
{
    public class EmpresaRepositorio : Repositorio<Empresa>, IEmpresaRepositorio
    {
        public EmpresaRepositorio(MedicionDbContext _context) : base(_context)
        {
        }
    }
}