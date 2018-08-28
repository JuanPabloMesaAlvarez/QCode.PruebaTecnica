using QCode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Application.Services.Contract
{
    public interface ILoginServiceController
    {
        void LogIn(Usuario usuario);
    }
}
