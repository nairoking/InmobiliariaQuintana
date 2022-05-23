using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class Inmueble
    {
        [Display(Name = "Código")]
        [Key]
        public int IdInmueble { get; set; }
      
        public string Direccion { get; set; }
       
        public int Ambientes { get; set; }
        
        public int Superficie { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        [Display(Name = "Disponible")]
        public string Estado { get; set; }

        [Display(Name = "Dueño")]
        public int PropietarioId { get; set; }
        [ForeignKey(nameof(PropietarioId))]
        public Propietario Duenio { get; set; }
    }
}
