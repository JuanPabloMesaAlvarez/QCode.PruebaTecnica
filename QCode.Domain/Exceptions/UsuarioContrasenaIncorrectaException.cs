using System;

namespace QCode.Domain.Exceptions
{
    public class UsuarioContrasenaIncorrectaException : Exception
    {
        public UsuarioContrasenaIncorrectaException()
            : base("La contraseña es incorrecta")
        {

        }
    }
}
