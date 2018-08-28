using QCode.Application.Services.Contract;
using QCode.Domain;
using QCode.DomainServices;
using QCode.Infrastructure.ExcelHandler;
using System.Collections.Generic;

namespace QCode.Application.Services.Impl
{
    class VehiculosServiceController : IVehiculosServiceController
    {
        private readonly IVehiculosService service;
        private readonly IExcelHandler xlsService;

        public VehiculosServiceController(IVehiculosService service, IExcelHandler xlsService)
        {
            this.service = service;
            this.xlsService = xlsService;
        }

        public bool CrearNuevoVehiculo(Vehiculo vehiculo)
        {
            return service.CrearNuevoVehiculo(vehiculo);
        }

        public bool ModificarVehiculo(Vehiculo vehiculo)
        {
            return service.ModificarVehiculo(vehiculo);
        }

        public Vehiculo TraerVehiculo(string placa)
        {
            return service.TraerVehiculo(placa);
        }

        public IEnumerable<Vehiculo> TraerVehiculos()
        {
            return service.TraerVehiculos();
        }

        public bool ImportarVehiculos(string fileVehiculosImportados)
        {
            var xlsData = xlsService.ReadFileData(fileVehiculosImportados);
            List<Vehiculo> data = new List<Vehiculo>();
            for (int row = 0; row < xlsData.Rows.Count; row++)
            {
                data.Add(new Vehiculo
                {
                    Placa = xlsData.Rows[row][0].ToString(),
                    Modelo = int.Parse(xlsData.Rows[row][1].ToString()),
                });
            }
            return service.ImportarVehiculos(data);
        }
    }
}
