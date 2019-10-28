using Medicion.Datos.Repositorio.Core;
using Medicion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Datos.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(MedicionDbContext _context) : base(_context)
        {
        }
    }
}