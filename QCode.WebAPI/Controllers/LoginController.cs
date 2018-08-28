using QCode.Application.Services.Contract;
using QCode.Domain;
using System.Web.Http;

namespace QCode.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginServiceController service;

        public LoginController(ILoginServiceController service)
        {
            this.service = service;
        }

        // POST: api/Login
        public Usuario Post([FromBody]Usuario value)
        {
            service.LogIn(value);
            return value;
        }
        
    }
}
