using QCode.Application.Services.Contract;
using QCode.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace QCode.WebAPI.Controllers
{
    public class VehiculosController : ApiController
    {
        private readonly IVehiculosServiceController service;

        public VehiculosController(IVehiculosServiceController service)
        {
            this.service = service;
        }

        // GET: api/Vehiculos
        public IEnumerable<Vehiculo> Get()
        {
            return service.TraerVehiculos();
        }

        // GET: api/Vehiculos/5
        public Vehiculo Get(string id)
        {
            return service.TraerVehiculo(id);
        }

        // POST: api/Vehiculos
        public void Post([FromBody]Vehiculo value)
        {
            service.CrearNuevoVehiculo(value);
        }

        // PUT: api/Vehiculos/5
        public void Put(string id, [FromBody]Vehiculo value)
        {
            service.ModificarVehiculo(value);
        }
    }
}
