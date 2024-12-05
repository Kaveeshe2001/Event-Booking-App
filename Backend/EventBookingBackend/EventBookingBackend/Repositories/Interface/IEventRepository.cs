using EventBookingBackend.Helpers;
using EventBookingBackend.Models;

namespace EventBookingBackend.Repositories.Interface
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task<List<Event?>> GetByCategoryAsync(int id);
        Task<List<Event?>> GetByStoreAsync(int id, QueryObject? query = null);
        Task<Event> CreateAsync(Event eventModel);
        Task<Event?> UpdateAsync(int id, Event eventModel);
        Task<Event?> DeleteAsync(int id);
        Task<int> CountAsync(int id);
    }
}
