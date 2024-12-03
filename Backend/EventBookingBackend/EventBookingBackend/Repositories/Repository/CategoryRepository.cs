using EventBookingBackend.Data;
using EventBookingBackend.Models;
using EventBookingBackend.Repositories.Interface;

namespace EventBookingBackend.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
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
