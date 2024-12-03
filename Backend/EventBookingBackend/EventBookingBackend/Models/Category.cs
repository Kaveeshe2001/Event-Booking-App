using System.ComponentModel.DataAnnotations;

namespace EventBookingBackend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
