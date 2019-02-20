using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoBuzon.Models
{
    public class Tecnico
    {
        public Tecnico()
        {
            Quejatecnico = new HashSet<Quejatecnico>();   
        }

        public int IdTecnico{ get; set; }
        [Display(Name = "Cédula")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string CedulaTecnico { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(100)]
        [Required]
        public string NombresTecnico { get; set; }
        [Display(Name = "Apellido")]
        [StringLength(100)]
        [Required]
        public string ApellidosTecnico { get; set; }
        [Display(Name = "Teléfono")]
        [Phone]
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string TelefonoTecnico { get; set; }
        [Display(Name = "Username")]
        [StringLength(100)]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Pasword")]
        [StringLength(100)]
        [Required]
        public string Pasword { get; set; }
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        [Required]
        public string CorreoTecnico { get; set; }

        public ICollection<Quejatecnico> Quejatecnico { get; set; }
        
    }
}
