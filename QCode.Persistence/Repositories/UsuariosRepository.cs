using QCode.Domain;
using QCode.Domain.Repositories;
using QCode.Persistence.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Persistence.Repositories
{
    class UsuariosRepository : IUsuariosRepository
    {
        private readonly DomainModel _contexto;

        public UsuariosRepository(DomainModel contexto)
        {
            _contexto = contexto;
        }

        public Usuario TraerUsuarioPorId(string usuarioId)
        {
            return _contexto.Usuarios.Find(usuarioId);
        }
    }
}
