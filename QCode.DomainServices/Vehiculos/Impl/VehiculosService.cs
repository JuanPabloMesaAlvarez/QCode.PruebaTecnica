using QCode.Domain.Repositories;
using QCode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using QCode.Domain.Exceptions;

namespace QCode.DomainServices
{
    public class VehiculosService : IVehiculosService
    {
        private readonly IUnitOfWork unitOfWork;

        public VehiculosService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool CrearNuevoVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new NullReferenceException("El vehiculo no esta definido");
            }
            vehiculo.FechaInsercion = DateTime.Now;
            vehiculo.Activo = true;
            return unitOfWork.VehiculosRepository.CrearVehiculo(vehiculo);
        }

        public bool ModificarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new NullReferenceException("El vehiculo no esta definido");
            }
            Vehiculo dbVehiculo = unitOfWork.VehiculosRepository.TraerVehiculoPorPlaca(vehiculo.Placa);
            dbVehiculo.Modelo = vehiculo.Modelo;
            dbVehiculo.Imagen = vehiculo.Imagen;
            unitOfWork.VehiculosRepository.ModificarVehiculo(dbVehiculo);
            unitOfWork.SaveChanges();
            return true;
        }

        public Vehiculo TraerVehiculo(string placa)
        {
            if (placa == string.Empty)
            {
                throw new PlacaInvalidaException();
            }
            return unitOfWork.VehiculosRepository.TraerVehiculoPorPlaca(placa);
        }

        public IEnumerable<Vehiculo> TraerVehiculos()
        {
            return unitOfWork.VehiculosRepository.TraerVehiculos();
        }

        public bool ImportarVehiculos(List<Vehiculo> vehiculosImportados)
        {
            if (vehiculosImportados == null)
            {
                throw new NullReferenceException("No se encontraron vehiculos para importar");
            }

            string[] placas = vehiculosImportados.Select(p => p.Placa).ToArray();
            foreach (Vehiculo vehiculo in vehiculosImportados)
            {
                var dbVehiculo = unitOfWork.VehiculosRepository.TraerVehiculoPorPlaca(vehiculo.Placa);
                if (dbVehiculo == null)
                {
                    CrearNuevoVehiculo(vehiculo);
                    continue;
                }

                vehiculo.FechaInsercion = DateTime.Now;
                ModificarVehiculo(vehiculo);
            }

            var vehiculos = unitOfWork.VehiculosRepository.TraerVehiculos().Where(v => !placas.Contains(v.Placa)).ToList();
            vehiculos.ForEach(v =>
            {
                v.Activo = false;
                ModificarVehiculo(v);
            });
            unitOfWork.SaveChanges();
            return true;
        }
    }
}