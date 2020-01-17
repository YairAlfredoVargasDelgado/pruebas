using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pruebas.Data;
using Pruebas.Models;

namespace Pruebas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly Context _context;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            Context context
        )
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Mapas");
            }
            return View();
        }

        public IActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    var u = await _context.Users.FindAsync(user.Id);
                    ((Usuario)u).Conectado = true;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Mapas");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("UserName,Nombres,Apellidos,Clave,ConfirmacionClave")] Usuario usuario)
        {
            var user = usuario;
            var result = await _userManager.CreateAsync(user, user.Clave);

            if (result.Succeeded)
            {
                var sigInResult = await _signInManager.PasswordSignInAsync(user, user.Clave, false, false);
                if (sigInResult.Succeeded)
                {
                    var u = await _context.Users.FindAsync(user.Id);
                    ((Usuario)u).Conectado = true;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Mapas");
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            var cu = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ((Usuario)cu).Conectado = false;
            await _context.SaveChangesAsync();

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
