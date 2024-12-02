using System.ComponentModel.DataAnnotations;

namespace EventBookingBackend.Models.DTO.Account
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
