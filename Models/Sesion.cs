using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enums;
using Pruebas.Models.Enums;

namespace Pruebas.Models
{
    public class Sesion : BaseEntity
    {
        public class InicioDeSesion
        {
            [MaxLength(20, ErrorMessage = "El largo máximo es de 20")]
            [MinLength(10, ErrorMessage = "El largo mínimo es de 10")]
            [DisplayName("Nombre de usuario")]
            public string NombreDeUsuario { get; set; }

            [MaxLength(20, ErrorMessage = "El largo máximo es de 20")]
            [MinLength(10, ErrorMessage = "El largo mínimo es de 10")]
            [DataType(DataType.Password)]
            [DisplayName("Clave")]
            public string Clave { get; set; }
        }

        [NotMapped]
        public string NombreUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public UsuarioState Estado { get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [DisplayName("Fecha de finalización")]
        public DateTime FechaFinalizacion { get; set; }

        public string Ip { get; set; }

        public float Latitud { get; set; }

        public float Longitud { get; set; }

        public Sesion() { }
    }
}