using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBookingBackend.Models.DTO.Event
{
    public class CreateEventDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Title must be 5 characters.")]
        [MaxLength(200, ErrorMessage ="Title cannot be over 200 characters")]
        public string EventName { get; set; } = string.Empty;

        public string Image { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal TicketPrice { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        [Required]
        public string Capacity { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
    }
}
