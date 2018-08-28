using QCode.Domain;
using System.Collections.Generic;

namespace QCode.DomainServices
{
    public interface IVehiculosService
    {
        bool CrearNuevoVehiculo(Vehiculo vehiculo);
        IEnumerable<Vehiculo> TraerVehiculos();
        Vehiculo TraerVehiculo(string placa);
        bool ModificarVehiculo(Vehiculo vehiculo);
        bool ImportarVehiculos(List<Vehiculo> vehiculosImportados);
    }
}