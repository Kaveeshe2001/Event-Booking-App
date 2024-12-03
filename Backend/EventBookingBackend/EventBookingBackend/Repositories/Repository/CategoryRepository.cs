using EventBookingBackend.Models;
using EventBookingBackend.Repositories.Interface;

namespace EventBookingBackend.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> CreateAsync(Category categorymodel)
        {
            throw new NotImplementedException();
        }
        
        public Task<Category?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(int id, Category categorymodel)
        {
            throw new NotImplementedException();
        }
    }
}
