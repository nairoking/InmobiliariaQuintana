using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class Pago
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Numero de pago")]
        public int NumeroPago { get; set; }
        [Display(Name = "Fecha de pago")]
        public DateTime FechaPago { get; set; }
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }
        [Display(Name = "Contrato")]
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        [Display(Name = "Ultima actualizacion")]
        public DateTime? FechaUpdate { get; set; }
       

    }
}
