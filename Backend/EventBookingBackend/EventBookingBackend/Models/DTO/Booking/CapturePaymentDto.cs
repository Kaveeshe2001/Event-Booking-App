namespace EventBookingBackend.Models.DTO.Booking
{
    public class CapturePaymentDto
    {
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string PaymentIntentId { get; set; }
    }
}
