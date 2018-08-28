using QCode.Domain;
using System.Collections.Generic;

namespace QCode.Application.Services.Contract
{
    public interface IVehiculosServiceController
    {
        IEnumerable<Vehiculo> TraerVehiculos();
        Vehiculo TraerVehiculo(string placa);
        bool CrearNuevoVehiculo(Vehiculo vehiculo);
        bool ModificarVehiculo(Vehiculo vehiculo);
        bool ImportarVehiculos(string fileVehiculosImportados);
    }
}
