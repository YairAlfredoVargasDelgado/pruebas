using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebas.Data;
using Pruebas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pruebas.Controllers
{
    public class MapasController : Controller
    {
        private readonly Context _context;

        public MapasController(Context context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.UltimaPagina = Math.Ceiling(_context.Users.Count() / 10.0);
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<List<Usuario>> CargarUsuarios(int from, int to)
        {
            List<Usuario> l = new List<Usuario>();
            if (from < 0) {
                return l;
            }
            if (to < 0) {
                return l;
            }
            if (to < from) {
                return l;
            }
            return await _context.Users.Where(u => ((Usuario)u).Conectado == true)
                                            .Skip(from)
                                            .Take(to)
                                            .Cast<Usuario>()
                                            .ToListAsync();
        }
    }
}
