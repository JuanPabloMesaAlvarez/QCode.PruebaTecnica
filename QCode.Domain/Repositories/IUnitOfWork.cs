using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IUsuariosRepository UsuariosRepository { get; }
        IVehiculosRepository VehiculosRepository { get; }
        IReparacionOrdenesRepository ReparacionOrdenesRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
