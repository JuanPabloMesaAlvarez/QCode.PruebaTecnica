using QCode.Domain;
using QCode.Domain.Exceptions;
using QCode.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace QCode.DomainServices
{
    public class ReparacionService : IReparacionService
    {
        private readonly IUnitOfWork unitOfWork;

        public ReparacionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool IngresarVehiculoAReparacion(ReparacionOrden orden)
        {
            if (orden == null)
            {
                throw new NullReferenceException("La orden no esta definida");
            }
            
            orden.Vehiculo = TraerVehiculo(orden.Placa);
            if(orden.Vehiculo == null)
            {
                throw new VehiculoNoExisteException();
            }

            decimal incremento = 1;
            orden.Valor = 200000;
            if (orden.Fecha.Day % 2 == 0)
            {
                incremento += 0.05m;
            }
            if (orden.Vehiculo.Modelo <= 1997)
            {
                incremento += 0.2m;
            }

            orden.Valor = orden.Valor * incremento;

            unitOfWork.ReparacionOrdenesRepository.IngresarOrdenDeReparacion(orden);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool RetirarVehiculoDeReparacion(int orden)
        {
            if (orden <= 0)
            {
                throw new NumeroDeOrdenInvalidoException();
            }

            ReparacionOrden dbOrden = unitOfWork.ReparacionOrdenesRepository.TraerOrdeneDeReparacionPorId(orden);
            unitOfWork.ReparacionOrdenesRepository.RetirarOrdenDeReparacion(dbOrden);
            unitOfWork.SaveChanges();
            return true;
        }

        public ReparacionOrden TraerOrden(int orden)
        {
            return unitOfWork.ReparacionOrdenesRepository.TraerOrdeneDeReparacionPorId(orden);
        }

        public IEnumerable<ReparacionOrden> TraerOrdenes()
        {
            return unitOfWork.ReparacionOrdenesRepository.TraerOrdenesDeReparacion();
        }

        public Vehiculo TraerVehiculo(string placa)
        {
            return unitOfWork.VehiculosRepository.TraerVehiculoPorPlaca(placa);
        }
    }
}