using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Categorias
    {
        [Key]
       
        public int CategoriaId { get; set; }

        [Range(minimum: 1, maximum: 200000000, ErrorMessage = "El rango de este campo debe ser mayor a 0.")]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int UsuarioId { get; set; }

        
        public string Nombre { get; set; }


        public Categorias()
        {
            CategoriaId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;

        }
    }
}