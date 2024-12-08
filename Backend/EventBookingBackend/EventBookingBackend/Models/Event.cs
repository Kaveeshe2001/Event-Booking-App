using EventBookingBackend.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingBackend.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public string Image {  get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TicketPrice { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateOnly Date {  get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        [Required]
        public string Capacity { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public ICollection<Booking> Booking { get; set; }

    }
}
