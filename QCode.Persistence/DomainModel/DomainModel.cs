using QCode.Domain;
using System.Data.Entity;

namespace QCode.Persistence.DomainModels
{
    public class DomainModel : DbContext
    {
        public DomainModel()
            : base("QCodeCnn")
        {
            Usuarios = base.Set<Usuario>();
            Vehiculos = base.Set<Vehiculo>();
            ReparacionOrdenes = base.Set<ReparacionOrden>();
        }

        public DbSet<Usuario> Usuarios { get; private set; }
        public DbSet<Vehiculo> Vehiculos { get; private set; }
        public DbSet<ReparacionOrden> ReparacionOrdenes { get; private set; }

    }
}
