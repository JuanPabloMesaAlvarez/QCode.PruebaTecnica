using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Domain.Repositories
{
    public interface IUsuariosRepository
    {
        Usuario TraerUsuarioPorId(string usuarioId);
    }
}
