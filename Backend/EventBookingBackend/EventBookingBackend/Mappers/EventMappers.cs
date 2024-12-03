using EventBookingBackend.Models;
using EventBookingBackend.Models.DTO.Event;

namespace EventBookingBackend.Mappers
{
    public static class EventMappers
    {
        public static EventDto ToEventDto(this Event eventmodel)
        {
            return new EventDto
            {
                Id = eventmodel.Id,
                EventName = eventmodel.EventName,
                Image = eventmodel.Image,
                Description = eventmodel.Description,
                TicketPrice = eventmodel.TicketPrice,
                Location = eventmodel.Location,
                Date = eventmodel.Date,
                Time = eventmodel.Time,
                Capacity = eventmodel.Capacity,
                CreatedOn = eventmodel.CreatedOn,
                CategoryId = eventmodel.CategoryId,
                UserId = eventmodel.UserId,
            };
        }
    }
}
