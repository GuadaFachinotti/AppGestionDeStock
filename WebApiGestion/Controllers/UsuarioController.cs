using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Text;
using Gestion.Core.Entities;
using Gestion.Core.Business;

namespace WebApiGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBusiness _usuarioBusiness;
        public UsuarioController(UsuarioBusiness usuarioBusiness,
                                   OperacionesBusiness operacionesBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }
        [HttpGet("GenerarUsuario/{nombreUsuario}/{password}")]
        // Esta función recibe como parámetro nombreUsuario y password y devuelve un Hash y Salt válidos para ese password
        //Al utilizar de retorno IActionResult, podemos devolver diferentes tipos de respuestas HTTP, como Ok, BadRequest, NotFound, StatusCode, etc.
        //ej 404 not found, 200 ok, 500 internal server error, 401 unauthorized
        public IActionResult GenerarUsuario(string nombreUsuario, string password)
        {
            try
            {
                // Se crea un objeto del tipo Usuario
                var result = new Usuario();

                // Se carga el nombre
                result.Nombre = nombreUsuario;

                // Llamo a la función GenerarPasswordHash para obtener un Hash y Salt válidos para el password
                var (hash, salt) = GenerarPasswordHash(password);
                result.Hash = hash;
                result.Salt = salt;

                // Llamada al negocio para dar de alta al usuario
                _usuarioBusiness.AltaUsuario(result);

                // Retorna el resultado como un 200 OK con el usuario creado
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Retorna un 500 Internal Server Error con el mensaje de la excepción
                return StatusCode(500, $"Error al generar el usuario: {ex.Message}");
            }
        }

        // Esta función recibe como parámetro el password y genera un hash y salt válidos para él y devuelve una tupla
        [HttpGet("GenerarPasswordHash/{password}")]
        private (string hash, string salt) GenerarPasswordHash(string password)
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
