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
        //Esta funcion recibe como parametro nombreUsuario y password y devuelve un Hash y Salt validos para ese password
        public Usuario GenerarUsuario(string nombreUsuario, string password)
        {
            //Se crea un onjeto del tipo Usuario
            var result = new Usuario();

            //Se carga el nombre
            result.Nombre = nombreUsuario;

            //Llamo a la funcion GenerarPasswordHash para obtener un Hash y Salt válidos para el password
            var (hash, salt) = GenerarPasswordHash(password);
            result.Hash = hash;
            result.Salt = salt;

            return result ;
        }

        // Esta función recibe como parámetro el password y genera un hash y salt válidos para él y devuelve una tupla
        [HttpGet("GenerarPasswordHash/{password}")]
        public (string hash, string salt) GenerarPasswordHash(string password)
        {
            // Crea un array de bytes para almacenar el salt
            var saltBytes = new byte[16];

            // Usa RNGCryptoServiceProvider para llenar el array de bytes con valores aleatorios
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);  // Genera bytes aleatorios para el salt
            }

            // Convierte los bytes del salt a una cadena en base64
            string salt = Convert.ToBase64String(saltBytes);

            // Usa SHA256 para crear un hash del password combinado con el salt
            using (SHA256 sha256 = SHA256.Create())
            {
                // Combina el password y el salt en una sola cadena
                var saltedPassword = password + salt;

                // Convierte la cadena combinada a un array de bytes
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);

                // Genera el hash de la cadena combinada
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);

                // Convierte los bytes del hash a una cadena en base64
                string hash = Convert.ToBase64String(hashBytes);

                // Retorna una tupla con el hash y el salt
                return (hash, salt);
            }
        }

    }
}
