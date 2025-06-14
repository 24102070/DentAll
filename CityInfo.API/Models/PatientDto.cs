using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class PatientDto
    {
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Phone { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";
        [Required]
        public DateTime CreatedAt { get; set; }

        public PatientDto() { }
    }
}
