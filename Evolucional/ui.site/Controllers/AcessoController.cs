using application.evolucional;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using ui.site.Models;

namespace ui.site.Controllers
{
    public class AcessoController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Entrar(string returnUrl)
        {
            if (HttpContext?.User?.Identity.IsAuthenticated == true)
            {
                return Redirect("~/");
            }

            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Entrar([FromServices] IAutenticarUsuario autenticarUsuario, LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {                                
                if (!autenticarUsuario.Autenticar(model.Usuario, model.Senha))
                {
                    ModelState.AddModelError(string.Empty, "Usuário e senha inválidos");

                    return View(model);
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Usuario),
                        new Claim(ClaimTypes.Role, "Role padrão")
                    };
                    
                    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Acesso"));

                    var propriedades = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.Now.AddHours(2),
                        IsPersistent = true
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, propriedades);
                }

                return Redirect(Url.IsLocalUrl(model.ReturnUrl) ? model.ReturnUrl : "~/");
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Sair()
        {
            if (HttpContext?.User?.Identity.IsAuthenticated == true)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return Redirect("~/");
        }
    }
}