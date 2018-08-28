using System.Collections.Generic;
using QCode.Application.Services.Contract;
using QCode.Domain;
using QCode.DomainServices;

namespace QCode.Application.Services.Impl
{
    class OrdenesReparacionServiceController : IOrdenesReparacionServiceController
    {
        private IReparacionService service;

        public OrdenesReparacionServiceController(IReparacionService service)
        {
            this.service = service;
        }

        public bool IngresarVehiculoAReparacion(ReparacionOrden orden)
        {
            return service.IngresarVehiculoAReparacion(orden);
        }

        public bool RetirarVehiculoDeReparacion(int orden)
        {
            return service.RetirarVehiculoDeReparacion(orden);
        }

        public ReparacionOrden TraerOrden(int orden)
        {
            return service.TraerOrden(orden);
        }

        public IEnumerable<ReparacionOrden> TraerOrdenes()
        {
            return service.TraerOrdenes();
        }
    }
}
