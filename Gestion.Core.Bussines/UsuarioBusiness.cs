using Gestion.Core.Data;
using Gestion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Business
{
    public class UsuarioBusiness
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioBusiness(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAllUsuarios();
        }

    }
}
