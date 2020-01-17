using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Pruebas.Models;

namespace Pruebas.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Pruebas.Models.Usuario> Usuario { get; set; }
        public DbSet<Pruebas.Models.Sesion> Sesion { get; set; }
    }
}