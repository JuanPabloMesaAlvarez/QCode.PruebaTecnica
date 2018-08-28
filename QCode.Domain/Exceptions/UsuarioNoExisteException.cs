using System;

namespace QCode.Domain.Exceptions
{
    public class UsuarioNoExisteException : Exception
    {
        public UsuarioNoExisteException()
            :base("El usuario no existe")
        {
        }
    }
}
