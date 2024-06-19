using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Text;
using Gestion.Core.Entities;

namespace WebApiGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("GenerarUsuario/{nombreUsuario}/{password}")]
        public Usuario GenerarUsuario(string nombreUsuario, string password)
        {
            var result = new Usuario();

            result.Nombre = nombreUsuario;
            var (hash, salt) = GenerarPasswordHash(password);
            result.Hash = hash;
            result.Salt = salt;

            return result ;
        }
        [HttpGet("GenerarPasswordHash/{password}")]
        public (string hash, string salt) GenerarPasswordHash(string password)
        {
            var saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            using (SHA256 sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                string hash = Convert.ToBase64String(hashBytes);
                return (hash, salt);
            }
        }
    }
}
