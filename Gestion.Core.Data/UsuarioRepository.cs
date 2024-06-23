using Gestion.Core.Configuration;
using Gestion.Core.Entities;
using Gestion.Core.Entities.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Core.Data
{
    public class UsuarioRepository
    {
        private readonly Config _config;

        public UsuarioRepository(Config config)
        {
            _config = config;
        }

        public List<Usuario> GetAllUsuarios()
        {
            var result = new List<Usuario>();

            using (var db = new GestionContext(_config))
            {
                result = db.Usuario.ToList();  
            }

            return result;
        }

        public void AltaUsuario(Usuario usuario)
        {
            using (var db = new GestionContext(_config))
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }
        }
    }
}
