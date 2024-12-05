using EventBookingBackend.Models;

namespace EventBookingBackend.Repositories.Interface
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(int id);
        Task<Store?> GetByUserIdAsync(string userId);
        Task<Store?> CreateAsync(Store storeModel);
        Task<Store?> UpdateAsync(int id, Store storeModel);
        Task<Store?> DeleteAsync(int id);
    }
}
