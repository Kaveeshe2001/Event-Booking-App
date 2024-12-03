using EventBookingBackend.Data;
using EventBookingBackend.Models;
using EventBookingBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Category?> CreateAsync(Category categorymodel)
        {
            await _context.Category.AddAsync(categorymodel);
            await _context.SaveChangesAsync();
            return categorymodel;
        }
        
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categorymodel = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);

            if (categorymodel == null)
            {
                return null;
            }

            _context.Category.Remove(categorymodel);
            await _context.SaveChangesAsync();
            return categorymodel;
        }

        public async Task<Category?> UpdateAsync(int id, Category categorymodel)
        {
            var existingcategory = await _context.Category.FindAsync(id);
            if (existingcategory == null)
            {
                return null;
            }

            existingcategory.CategoryName = categorymodel.CategoryName;
            existingcategory.Image = categorymodel.Image;

            await _context.SaveChangesAsync();
            return existingcategory;
        }
    }
}
