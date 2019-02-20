using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoBuzon.Models
{
    public class Quejatecnico
    {
        public int IdQuejatecnico { get; set; }
        [Display(Name = "Queja")]
        public int IdQ { get; set; }
        [Display(Name = "Tecnico")]
        public int IdTecnico { get; set; }
        public DateTime? Fecha { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Display(Name = "Queja")]
        public Quejas
            IdQNavigation
        { get; set; }
        [Display(Name = "Tecnico")]
        public Tecnico IdTecnicoNavigation { get; set; }
    }
}
