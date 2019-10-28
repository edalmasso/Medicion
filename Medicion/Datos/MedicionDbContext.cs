using Medicion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicion.Datos
{
    public class MedicionDbContext : IdentityDbContext<Usuario, Rol, int>
    {
        public MedicionDbContext(DbContextOptions<MedicionDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Contrato> Contratos { get; set; }

        public virtual DbSet<DatosPunto> DatosPuntos { get; set; }

        public virtual DbSet<Proyecto> Proyectos { get; set; }

        public virtual DbSet<PuntoEstudio> PuntoEstudios { get; set; }

        private void SeedDatabase(ModelBuilder builder)
        {
            // Se asegura que exista el registro con los datos indicados
            builder.Entity<Empresa>().HasData(
                new Empresa { Id = 1, CUIT = "123465", FechaCreacion = DateTime.Now, RazonSocial = "Empresa 1", Telefono = "4258965" },
                new Empresa { Id = 2, CUIT = "333465", FechaCreacion = DateTime.Now, RazonSocial = "Empresa 2", Telefono = "6546215" },
                new Empresa { Id = 3, CUIT = "654987", FechaCreacion = DateTime.Now, RazonSocial = "Empresa 3", Telefono = "8574" }
                );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Many to Manys
            #region Usuario Empresa
            // Esto se utiliza para indicarle a Entity Framework cómo tiene que 
            // interpretar las relaciones entre los objetos. Buscar en internet como FluentApi
            // En este caso, es una relación N a N entre Usuario y Empresa con una tabla asociativa
            // UsuarioEmpresa
            //builder.Entity<UsuarioEmpresa>()
            //            .HasKey(a => new { a.EmpresaId, a.UsuarioId });

            //builder.Entity<UsuarioEmpresa>()
            //       .HasOne(a => a.Empresa)
            //       .WithMany(a => a.UsuarioEmpresas)
            //       .HasForeignKey(a => a.EmpresaId);

            //builder.Entity<UsuarioEmpresa>()
            //       .HasOne(a => a.Usuario)
            //       .WithMany(a => a.UsuarioEmpresas)
            //       .HasForeignKey(a => a.UsuarioId);
            #endregion


            #endregion

            #region Campos calculados
            // Se puede usar para definir campos calculados
            //builder.Entity<Gestion>()
            //.Property(p => p.DiferenciaPresupuestadoArancel)
            //.HasComputedColumnSql($"{nameof(Gestion.MontoPresupuestado)} - {nameof(Gestion.MontoReal)}");
            #endregion

            SeedDatabase(builder);
        }
    }
}
