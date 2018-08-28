using QCode.Application.Services.Contract;
using QCode.Domain;
using QCode.DomainServices;

namespace QCode.Application
{
    public class LoginServiceController : ILoginServiceController
    {
        private ILoginService service;

        public LoginServiceController(ILoginService service)
        {
            this.service = service;
        }

        public void LogIn(Usuario usuario)
        {
            service.LogIn(usuario);
        }
    }
}
