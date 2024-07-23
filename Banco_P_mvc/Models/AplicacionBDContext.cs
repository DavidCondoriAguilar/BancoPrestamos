using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.UI;

namespace Banco_P_mvc.Models
{
    public class AplicacionBDContext : DbContext
    {
        public AplicacionBDContext() : base("DefaultConnection")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<DetalleAdquisicion> DetallesAdquisicion { get; set; }
        public DbSet<DetalleApertura> DetallesApertura { get; set; }
        public DbSet<DetalleSolicitud> DetallesSolicitud { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
