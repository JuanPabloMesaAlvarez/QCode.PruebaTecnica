using System.Collections.Generic;

namespace QCode.Domain.Repositories
{
    public interface IVehiculosRepository
    {
        IEnumerable<Vehiculo> TraerVehiculos();
        Vehiculo TraerVehiculoPorPlaca(string placa);
        bool CrearVehiculo(Vehiculo vehiculo);
        Vehiculo ModificarVehiculo(Vehiculo vehiculo);

    }
}
