using QCode.Domain;
using QCode.Domain.Repositories;
using QCode.Persistence.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Persistence.Repositories
{
    class ReparacionOrdenesRepository : IReparacionOrdenesRepository
    {

        private readonly DomainModel _contexto;

        public ReparacionOrdenesRepository(DomainModel contexto)
        {
            _contexto = contexto;
        }

        public bool IngresarOrdenDeReparacion(ReparacionOrden orden)
        {
            _contexto.ReparacionOrdenes.Add(orden);
            return true;
        }

        public bool RetirarOrdenDeReparacion(ReparacionOrden orden)
        {
            _contexto.ReparacionOrdenes.Remove(orden);
            return true;
        }

        public ReparacionOrden TraerOrdeneDeReparacionPorId(int idOrden)
        {
            return _contexto.ReparacionOrdenes.Include("Vehiculo").Where(orden => orden.ReparacionOrdenId == idOrden).First();
        }

        public IEnumerable<ReparacionOrden> TraerOrdenesDeReparacion()
        {
            return _contexto.ReparacionOrdenes;
        }
    }
}