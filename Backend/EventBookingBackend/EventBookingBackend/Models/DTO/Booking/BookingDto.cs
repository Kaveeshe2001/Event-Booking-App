using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingBackend.Models.DTO.Booking
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string PaymentIntentId { get; set; }
    }
}
