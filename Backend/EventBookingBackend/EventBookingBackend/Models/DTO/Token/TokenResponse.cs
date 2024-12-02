namespace EventBookingBackend.Models.DTO.Token
{
    public class TokenResponse
    {
        public string? TokenString { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
