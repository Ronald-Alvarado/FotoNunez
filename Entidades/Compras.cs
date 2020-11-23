using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class Compras
    {
        [Key]
        
        public int CompraId { get; set; }

        [Required(ErrorMessage = "Este campo no puede  estar vacio.")]
        [Range(minimum: 1, maximum: 10000000, ErrorMessage = "Este campo debe ser mayor a 0.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime Fecha { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalle> ComprasDetalle { get; set; }

        public Compras()
        {
            CompraId = 0;
            UsuarioId = 0;
            Monto = 0.0m;
            Fecha = DateTime.Now;

            ComprasDetalle = new List<ComprasDetalle>();
        }
    }
}