using EventBookingBackend.Models;
using EventBookingBackend.Models.DTO.Booking;

namespace EventBookingBackend.Mappers
{
    public static class BookingMappers
    {
        public static BookingDto ToBookingDto(this Booking bookingModel)
        {
            return new BookingDto
            {
                Id = bookingModel.Id,
                BookingDate = bookingModel.BookingDate,
                UserId = bookingModel.UserId,
                EventId = bookingModel.EventId,
                PaymentIntentId = bookingModel.PaymentIntentId,
            };
        }
    }
}
