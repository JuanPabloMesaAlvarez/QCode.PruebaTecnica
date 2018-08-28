using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Domain.Exceptions
{
    public class PlacaInvalidaException : Exception
    {
        public PlacaInvalidaException()
            : base("La placa no es valida")
        {

        }
    }
}
