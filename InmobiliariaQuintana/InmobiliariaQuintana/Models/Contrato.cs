using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class Contrato
    {
        [Display(Name = "Código Contrato")]
        public int IdContrato { get; set; }
        [Display(Name = "Nombre de Inquilino")]
        public int InquilinoId { get; set; }
        [Display(Name = "Código Inmueble")]
        public int InmuebleId { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta{ get; set; }

        public string NombreGarante { get; set; }
        public string DNIGarante { get; set; }
        public string TelefonoGarante { get; set; }
        public Inmueble inmueble { get; set; }
        public Inquilinos inqui { get; set; }
    }
}
