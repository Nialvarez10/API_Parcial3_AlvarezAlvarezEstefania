using System.ComponentModel.DataAnnotations;

namespace API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities
{
    public class Rooms : AuditBase
    {
        [Display(Name = "Number")]
        [MaxLength(3, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "¡The field {0} is required!")]
        public string Number { get; set; }
        public int MaxGuests { get; set; }

        [Required(ErrorMessage = "¡The field {0} is required!")]
        public bool Availability { get; set; }
        public Guid? HotelId { get; set; } //Fk
        public Hotels? Hotel { get; set; }
    }
}
