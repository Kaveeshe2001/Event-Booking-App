using System.ComponentModel.DataAnnotations;

namespace EventBookingBackend.Models.DTO.Account
{
    public class ChangePasswordDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
