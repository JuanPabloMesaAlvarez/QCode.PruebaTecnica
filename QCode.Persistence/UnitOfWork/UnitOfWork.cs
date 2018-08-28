using QCode.Domain.Repositories;
using QCode.Persistence.DomainModels;
using QCode.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainModel _contexto;

        public UnitOfWork()
        {
            _contexto = new DomainModel();
        }

        private IUsuariosRepository usuariosRepository;
        private IVehiculosRepository vehiculosRepository;
        private IReparacionOrdenesRepository reparacionOrdenesRepository;

        public IUsuariosRepository UsuariosRepository => usuariosRepository ?? (usuariosRepository = new UsuariosRepository(_contexto));
        public IVehiculosRepository VehiculosRepository => vehiculosRepository ?? (vehiculosRepository = new VehiculosRepository(_contexto));
        public IReparacionOrdenesRepository ReparacionOrdenesRepository => reparacionOrdenesRepository ?? (reparacionOrdenesRepository = new ReparacionOrdenesRepository(_contexto));

        public int SaveChanges()
        {
            return _contexto.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _contexto.SaveChangesAsync();
        }
    }
}
