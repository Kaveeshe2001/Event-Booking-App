using EventBookingBackend.Models;

namespace EventBookingBackend.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> CreateAsync(Category categorymodel);
        Task<Category?> UpdateAsync(int id, Category categorymodel);
        Task<Category?> DeleteAsync(int id);
    }
}
