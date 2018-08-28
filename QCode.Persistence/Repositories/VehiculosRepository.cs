using QCode.Domain.Repositories;
using QCode.Domain;
using QCode.Persistence.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace QCode.Persistence.Repositories
{
    class VehiculosRepository : IVehiculosRepository
    {
        private readonly DomainModel _contexto;

        public VehiculosRepository(DomainModel contexto)
        {
            _contexto = contexto;
        }

        public bool CrearVehiculo(Vehiculo vehiculo)
        {
            try
            {
                _contexto.Vehiculos.Add(vehiculo);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Vehiculo ModificarVehiculo(Vehiculo vehiculo)
        {
            var entry =_contexto.Entry(vehiculo);

            if (entry.State == EntityState.Detached)
            {
                _contexto.Vehiculos.Attach(vehiculo);
                entry = _contexto.Entry(vehiculo);
            }
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public Vehiculo TraerVehiculoPorPlaca(string placa)
        {
            return _contexto.Vehiculos.Find(placa);
        }

        public IEnumerable<Vehiculo> TraerVehiculos()
        {
            return _contexto.Vehiculos;
        }
    }
}
