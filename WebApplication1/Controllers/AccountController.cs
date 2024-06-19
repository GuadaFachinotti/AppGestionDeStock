using Gestion.Core.Business;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsuarioBusiness _usuarioBusiness;

        public AccountController(UsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _usuarioBusiness.GetAllUsuarios().FirstOrDefault(u => u.Nombre == model.Username);

            if (user != null && VerifyPassword(model.Password, user.Salt, user.Hash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString())
                }; 

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Propiedades adicionales si es necesario
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                //Esta línea inicia la sesión del usuario autenticado utilizando la identidad de claims
                //y establece las cookies de autenticación en el navegador del usuario.

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Inicio de sesión invalido");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private bool VerifyPassword(string password, string salt, string hash)
        {
            //Obtiene un hash generado a partir del password que ingreso el usuario y el salt de la base
            var hashToVerify = HashPassword(password, salt);

            //verifica que el hash de la base sea igual que el hash generado
            return hash == hashToVerify;
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                //Arma un string concatenan el password que ingreso con el salt
                var saltedPassword = password + salt;

                //transforma el string a un array de byte
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);

                //obtiene el hash en bytes a partir del array de bytes
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);

                //retorna el hash convertido en string
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}
