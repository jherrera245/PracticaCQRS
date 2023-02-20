using System.ComponentModel.DataAnnotations;

namespace APICQRS.Models
{
    public class Categorias
    {
        [Key]
        public int IdCatgeoria { get; set; }
        
        [Required]
        [StringLength(80, MinimumLength = 10)]
        public string NombreCategoria { get; set; }
        
        public string DesecripcionCategoria { get; set; }
    }
}
