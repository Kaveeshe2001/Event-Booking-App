using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingBackend.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Events { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
