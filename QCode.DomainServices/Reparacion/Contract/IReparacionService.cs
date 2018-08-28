using QCode.Domain;
using System.Collections.Generic;

namespace QCode.DomainServices
{
    public interface IReparacionService
    {
        bool IngresarVehiculoAReparacion(ReparacionOrden order);
        Vehiculo TraerVehiculo(string placa);
        IEnumerable<ReparacionOrden> TraerOrdenes();
        ReparacionOrden TraerOrden(int orden);
        bool RetirarVehiculoDeReparacion(int order);
    }
}