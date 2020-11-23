using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class VentasDetalle
    {
        [Key]
        
        public int VentasDetalleId { get; set; }

    
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 200000000, ErrorMessage = "El rango de este campo debe ser mayor a 0.")]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [MinLength(4, ErrorMessage = "Este campo no puede tener menos de 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "Ha alcanzado el maximo de caracteres.")]
        public String Descripcion { get; set; }

        
        public int Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        
        public decimal PrecioArticulo { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 200000000, ErrorMessage = "El rango de este campo debe ser mayor a 0.")]
        public int EventoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PrecioEvento { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Monto { get; set; }

        public VentasDetalle()
        {
            VentasDetalleId = 0;
            VentaId = 0;
            ArticuloId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            PrecioArticulo = 0;
            EventoId = 0;
            PrecioEvento = 0;
            Monto = 0;
        }

        public VentasDetalle(int ventaId, int articuloId, string descripcion, int cantidad, decimal precioArticulo, int eventoId, decimal precioEvento, decimal monto)
        {
            VentasDetalleId = 0;
            VentaId = ventaId;
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioArticulo = precioArticulo;
            EventoId = eventoId;
            PrecioEvento = precioEvento;
            Monto = monto;
        }


    }
}