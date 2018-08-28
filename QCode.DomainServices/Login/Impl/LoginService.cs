using QCode.Domain;
using QCode.Domain.Exceptions;
using QCode.Domain.Repositories;
using System;

namespace QCode.DomainServices
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void LogIn(Usuario usuario)
        {
            var dbUsuario = unitOfWork.UsuariosRepository.TraerUsuarioPorId(usuario.UsuarioId);
            if (dbUsuario == null)
            {
                throw new UsuarioNoExisteException();
            }

            if (usuario.Contrasena != dbUsuario.Contrasena)
            {
                throw new UsuarioContrasenaIncorrectaException();
            }
            usuario.Nombre = dbUsuario.Nombre;
            usuario.Contrasena = string.Empty;
            usuario.IsValid = true;
        }
    }
}