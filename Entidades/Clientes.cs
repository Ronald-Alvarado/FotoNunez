using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        
        public int ClienteId { get; set; }

        [Range(1, 20000000, ErrorMessage = "Este campo debe tener un rango mayor a 0.")]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int UsuarioId { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

       
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Sexo = string.Empty;
            FechaNacimiento = DateTime.Now;

        }
    }
}
