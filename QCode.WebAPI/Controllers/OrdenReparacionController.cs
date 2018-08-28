using QCode.Application.Services.Contract;
using QCode.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace QCode.WebAPI.Controllers
{
    public class OrdenesReparacionController : ApiController
    {
        private readonly IOrdenesReparacionServiceController service;

        public OrdenesReparacionController(IOrdenesReparacionServiceController service)
        {
            this.service = service;
        }

        // GET: api/OrdenesReparacion
        public IEnumerable<ReparacionOrden> Get()
        {
            return service.TraerOrdenes();
        }

        // GET: api/OrdenesReparacion/5
        public ReparacionOrden Get(int id)
        {
            return service.TraerOrden(id);
        }

        // POST: api/OrdenesReparacion
        public ReparacionOrden Post([FromBody]ReparacionOrden value)
        {
            service.IngresarVehiculoAReparacion(value);
            return value;
        }

        // DELETE: api/OrdenesReparacion/5
        public void Delete(int id)
        {
            service.RetirarVehiculoDeReparacion(id);
        }
    }
}
