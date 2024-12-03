using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingBackend.Models
{
    [Table("ApplicationUser")]
    public class User : IdentityUser
    {
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
