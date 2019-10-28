﻿using Medicion.Datos.Repositorio.Core;
using Medicion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Datos.Repositorio
{
    public class DatosPuntoRepositorio : Repositorio<DatosPunto>, IDatosPuntoRepositorio
    {
        public DatosPuntoRepositorio(MedicionDbContext _context) : base(_context)
        {
        }
    }
}