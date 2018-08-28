using QCode.Application.Services.Contract;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Http;

namespace QCode.WebAPI.Controllers
{
    public class ImportacionesController : ApiController
    {
        private readonly IVehiculosServiceController service;

        public ImportacionesController(IVehiculosServiceController service)
        {
            this.service = service;
        }

        // POST: api/Importaciones
        public void Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count == 0)
            {
                return;
            }

            string path = ConfigurationManager.AppSettings["files"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                path += "/" + postedFile.FileName;
                postedFile.SaveAs(path);
                break;
            }
            service.ImportarVehiculos(path);
        }
    }
}
