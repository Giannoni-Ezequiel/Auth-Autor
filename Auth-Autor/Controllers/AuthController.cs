using Auth_Autor.Datos;
using Microsoft.AspNetCore.Mvc;
using Auth_Autor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


namespace Auth_Autor.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(User usuario)
        {
            Logica_DA infoUser = new Logica_DA();
            var userAutenticado = infoUser.ValidarUsuario(usuario.emailUser, usuario.contraseniaUser);
            if (userAutenticado != null)
            {
                var claims = new List<Claim> 
                { 
                    new Claim(ClaimTypes.Name, userAutenticado.nombreUser),
                    new Claim("Correo", userAutenticado.emailUser)
                };

                foreach (string rol in userAutenticado.Rol) 
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else {return View(); }
            

        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Auth");
        }

    }
}
