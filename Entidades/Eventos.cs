using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Eventos
    {
        [Key]
        
        public int EventoId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 200000000, ErrorMessage = "El rango de este campo debe ser mayor a 0.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 200000000, ErrorMessage = "El rango de este campo debe ser mayor a 0.")]
        public int FotografoId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [MinLength(4, ErrorMessage = "Este campo no puede tener menos de 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "Ha alcanzado el maximo de caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Lugar { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime FechaFin { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Precio { get; set; }

        //[ForeignKey("EventoId")]
      //  public List<VentasDetalle> VentasDetalle { get; set; }

        public Eventos()
        {
            EventoId = 0;
            UsuarioId = 0;
            Descripcion = string.Empty;
            Lugar = string.Empty;
            FechaInicio = DateTime.Now;
            FechaFin = DateTime.Now;
            Precio = 0;

            //VentasDetalle = new List<VentasDetalle>();
        }
    }
}
