using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class Contrato
    {
        [Display(Name = "Código Contrato")]
        [Key]
        public int IdContrato { get; set; }
        [Display(Name = "Nombre de Inquilino")]
        [ForeignKey(nameof(InquilinoId))]

        public int InquilinoId { get; set; }
        [Display(Name = "Código Inmueble")]
        [ForeignKey(nameof(InmuebleId))]
        public int InmuebleId { get; set; }
        [Display(Name = "Inicio del Contrato")]
        public DateTime FechaDesde { get; set; }
        [Display(Name = "Fin del Contrato")]
        public DateTime FechaHasta{ get; set; }
        [Display(Name = "Garante")]
        public string NombreGarante { get; set; }
        [Display(Name = "DNI del Garante")]
        public string DNIGarante { get; set; }
        [Display(Name = "Telefono del Garante")]
        public string TelefonoGarante { get; set; }
        public Inmueble inmueble { get; set; }
        public Inquilinos inquilino { get; set; }
        public decimal Precio { get; set; }
    }
}
