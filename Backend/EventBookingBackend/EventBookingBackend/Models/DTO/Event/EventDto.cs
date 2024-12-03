namespace EventBookingBackend.Models.DTO.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Image {  get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TicketPrice { get; set; }
        public string Location {  get; set; } = string.Empty;
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public string Capacity {  get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public int StoreId { get; set; }
    }
}
