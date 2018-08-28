using QCode.Domain;
using System.Collections.Generic;

namespace QCode.Application.Services.Contract
{
    public interface IOrdenesReparacionServiceController
    {
        bool IngresarVehiculoAReparacion(ReparacionOrden orden);
        IEnumerable<ReparacionOrden> TraerOrdenes();
        ReparacionOrden TraerOrden(int orden);
        bool RetirarVehiculoDeReparacion(int orden);
    }
}
