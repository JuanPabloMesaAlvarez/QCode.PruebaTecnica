using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Domain.Repositories
{
    public interface IReparacionOrdenesRepository
    {
        bool IngresarOrdenDeReparacion(ReparacionOrden orden);
        IEnumerable<ReparacionOrden> TraerOrdenesDeReparacion();
        ReparacionOrden TraerOrdeneDeReparacionPorId(int idOrden);
        bool RetirarOrdenDeReparacion(ReparacionOrden orden);
    }
}
