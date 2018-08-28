using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Http;

namespace QCode.WebAPI.Controllers
{
    public class ImagenesController : ApiController
    {
        // POST: api/Imagenes
        public byte[] Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count == 0)
            {
                return new byte[0];
            }

            string path = ConfigurationManager.AppSettings["imagenes"];
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
            var result = File.ReadAllBytes(path);
            File.Delete(path);
            return result;
        }
    }
}
