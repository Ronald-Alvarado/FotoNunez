using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class Ventas
    {
        [Key]
        
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 200000000, ErrorMessage = "El rango de este campo debe ser mayor a 0.")]
        public int ClienteId { get; set; }

        public string Nombres { get; set; }

      
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentasDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Fecha = DateTime.Now;
            Total = 0.0m;

            VentasDetalle = new List<VentasDetalle>();
        }


    }
}