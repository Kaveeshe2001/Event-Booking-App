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
                StoreId = eventmodel.StoreId,
            };
        }

        public static Event ToEventFromCreate(this CreateEventDto eventDto, int storeId)
        {
            return new Event
            {
                EventName = eventDto.EventName,
                Image = eventDto.Image,
                Description = eventDto.Description,
                TicketPrice = eventDto.TicketPrice,
                Location = eventDto.Location,
                Date = eventDto.Date,
                Time = eventDto.Time,
                Capacity = eventDto.Capacity,
                CategoryId = eventDto.CategoryId,
                StoreId = storeId
            };
        }

        public static Event ToEventFromUpdate(this UpdateEventDto eventDto, int id)
        {
            return new Event
            {
                EventName = eventDto.EventName,
                Image = eventDto.Image,
                Description = eventDto.Description,
                TicketPrice = eventDto.TicketPrice,
                Location = eventDto.Location,
                Date = eventDto.Date,
                Time = eventDto.Time,
                Capacity = eventDto.Capacity,
                CategoryId = eventDto.CategoryId,
                StoreId = eventDto.StoreId,
            };
        }
    }
}
