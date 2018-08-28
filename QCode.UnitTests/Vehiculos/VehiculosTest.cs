using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCode.Domain;
using QCode.DomainServices;
using QCode.Persistence;

namespace QCode.UnitTests.Vehiculos
{
    [TestClass]
    public class VehiculosTest
    {
        [TestMethod]
        public void CrearVehiculo_Ok_TestMethod()
        {
            //Arrange
            Vehiculo vehiculo = new Vehiculo();
            IVehiculosService service = new VehiculosService(new UnitOfWork());
            bool result;

            vehiculo.Placa = "WJY306";
            vehiculo.Modelo = 2015;
            vehiculo.Imagen = null;

            //Act
            result = service.CrearNuevoVehiculo(vehiculo);

            //Assert
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void CrearVehiculo_Fail_TestMethod()
        {
            //Arrange
            Vehiculo vehiculo = new Vehiculo();
            IVehiculosService service = new VehiculosService(new UnitOfWork());
            bool result;

            vehiculo.Placa = "WJY306";
            vehiculo.Modelo = 2015;
            vehiculo.Imagen = null;

            //Act
            result = service.CrearNuevoVehiculo(vehiculo);

            //Assert
            Assert.AreEqual(false, result);
        }


        [TestMethod]
        public void ModificarVehiculo_Existente_TestMethod()
        {
            //Arrange
            IVehiculosService service = new VehiculosService(new UnitOfWork());
            bool result;

            Vehiculo vehiculo = service.TraerVehiculo("WJY306");
            

            //Act
            result = service.ModificarVehiculo(vehiculo);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ModificarVehiculo_No_Existente_TestMethod()
        {
            //Arrange
            IVehiculosService service = new VehiculosService(new UnitOfWork());
            bool result;

            Vehiculo vehiculo = service.TraerVehiculo("0");


            //Act
            result = service.ModificarVehiculo(vehiculo);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
