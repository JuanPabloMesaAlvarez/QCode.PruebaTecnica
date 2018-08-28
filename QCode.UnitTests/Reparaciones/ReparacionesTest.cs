using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCode.Domain;
using QCode.DomainServices;
using QCode.Persistence;

namespace QCode.UnitTests.Reparaciones
{
    [TestClass]
    public class ReparacionesTest
    {
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException), "A userId of null was inappropriately allowed.")]
        public void IngresarVehiculo_Ok_TestMethod()
        {
            //Arrange
            ReparacionOrden order = new ReparacionOrden();
            IReparacionService service = new ReparacionService(new UnitOfWork());
            Vehiculo vehiculo = new Vehiculo();
            bool result;

            vehiculo = service.TraerVehiculo("WJY306");
            order.Vehiculo = vehiculo;
            order.Fecha = DateTime.Now;

            //Act
            result = service.IngresarVehiculoAReparacion(order);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IngresarVehiculo_Fail_TestMethod()
        {
            //Arrange
            ReparacionOrden order = new ReparacionOrden();
            IReparacionService service = new ReparacionService(new UnitOfWork());
            Vehiculo vehiculo = new Vehiculo();
            bool result;

            vehiculo = service.TraerVehiculo("W");
            order.Vehiculo = vehiculo;
            order.Fecha = DateTime.Now;

            //Act
            result = service.IngresarVehiculoAReparacion(order);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void RetirarVehiculo_Ok_TestMethod()
        {
            //Arrange
            ReparacionOrden order;
            IReparacionService service = new ReparacionService(new UnitOfWork());
            bool result;

            order = service.TraerOrden(1);

            //Act
            result = service.RetirarVehiculoDeReparacion(1);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RetirarVehiculo_Fail_TestMethod()
        {
            //Arrange
            ReparacionOrden order;
            IReparacionService service = new ReparacionService(new UnitOfWork());
            bool result;

            order = service.TraerOrden(-1);

            //Act
            result = service.RetirarVehiculoDeReparacion(-1);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
