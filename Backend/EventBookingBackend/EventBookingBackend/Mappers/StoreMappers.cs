using EventBookingBackend.Models;
using EventBookingBackend.Models.DTO.Store;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace EventBookingBackend.Mappers
{
    public static class StoreMappers
    {
        public static StoreDto ToStoreDto(this Store storeModel)
        {
            return new StoreDto
            {
                Id = storeModel.Id,
                Name = storeModel.Name,
                Email = storeModel.Email,
                PhoneNumber = storeModel.PhoneNumber,
                Address = storeModel.Address,
                CoverPhoto = storeModel.CoverPhoto,
                ProfilePhoto = storeModel.ProfilePhoto,
                CreatedOn = storeModel.CreatedOn,
                UserId = storeModel.UserId,
                Events = storeModel.Events.Select(a => a.ToEventDto()).ToList(),
            };
        }

        public static Store ToStoreFromCreate(this CreateStoreDto storeDto, string userId)
        {
            return new Store
            {
                Name = storeDto.Name,
                Email = storeDto.Email,
                PhoneNumber = storeDto.PhoneNumber,
                Address = storeDto.Address,
                CoverPhoto = storeDto.CoverPhoto,
                ProfilePhoto = storeDto.ProfilePhoto,
                UserId = userId,
                Events = new List<Event>()
            };
        }

        public static Store ToStoreFromUpdate(this UpdateStoreDto storeDto, int id)
        {
            return new Store
            {
                Name = storeDto.Name,
                Email = storeDto.Email,
                PhoneNumber = storeDto.PhoneNumber,
                Address = storeDto.Address,
                CoverPhoto = storeDto.CoverPhoto,
                ProfilePhoto = storeDto.ProfilePhoto,
            };
        }
    }
}
