using QCode.Domain;

namespace QCode.DomainServices
{
    public interface ILoginService
    {
        void LogIn(Usuario usuario);
    }
}