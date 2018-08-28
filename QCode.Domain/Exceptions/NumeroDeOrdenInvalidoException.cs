using System;

namespace QCode.Domain.Exceptions
{
    public class NumeroDeOrdenInvalidoException : Exception
    {
        public NumeroDeOrdenInvalidoException() 
            : base("El numero de la orden no es valido")
        {

        }
    }
}
