using System.ComponentModel.DataAnnotations;

namespace EventBookingBackend.Models.DTO.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;
    }
}
