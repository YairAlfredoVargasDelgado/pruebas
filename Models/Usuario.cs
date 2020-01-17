using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Models.Enums;
using Pruebas.Models.Enums;

namespace Pruebas.Models
{
    public class Usuario : IdentityUser
    {
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Text)]
        public string Nombres { get; set; }

        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }

        public bool Conectado { get; set; }

        public UsuarioState Estado { get; set; }

        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        [NotMapped]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar clave")]
        public string ConfirmacionClave { get; set; }

        public Usuario() { }
    }
}