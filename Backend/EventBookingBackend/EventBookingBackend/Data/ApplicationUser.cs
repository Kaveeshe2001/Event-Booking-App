using Microsoft.AspNetCore.Identity;

namespace EventBookingBackend.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
