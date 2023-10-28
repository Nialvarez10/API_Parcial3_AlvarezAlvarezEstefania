using System.ComponentModel.DataAnnotations;

namespace API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities
{
    public class Hotels : AuditBase
    {
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "¡The field {0} is required!")]
        public string Name { get; set; }

    
        [Required(ErrorMessage = "¡The field {0} is required!")]
        public string Address { get; set; }

        [Range(1, 5, ErrorMessage = "Reputation must be in the range of 1 to 5 stars.")]
        public int Stars { get; set; }

        public ICollection<Rooms>? Room { get; set; }
    }
}
