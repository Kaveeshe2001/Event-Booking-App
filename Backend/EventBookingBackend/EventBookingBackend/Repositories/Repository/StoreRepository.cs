using EventBookingBackend.Data;
using EventBookingBackend.Models;
using EventBookingBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventBookingBackend.Repositories.Repository
{
    public class StoreRepository : IStoreRepository
    {

        private readonly ApplicationDbContext _context;

        public StoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Store>> GetAllAsync()
        {
            return await _context.Store.ToListAsync();
        }

        public async Task<Store?> CreateAsync(Store storeModel)
        {
            await _context.Store.AddAsync(storeModel);
            await _context.SaveChangesAsync();
            return storeModel;
        }
        
        public async Task<Store?> GetByIdAsync(int id)
        {
            return await _context.Store.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Store?> GetByUserIdAsync(string userId)
        {
            return await _context.Store.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<Store?> DeleteAsync(int id)
        {
            var storeModel = await _context.Store.FirstOrDefaultAsync(x => x.Id == id);

            if (storeModel == null)
            {
                return null;
            }

            _context.Store.Remove(storeModel);
            await _context.SaveChangesAsync();
            return storeModel;
        }

        public async Task<Store?> UpdateAsync(int id, Store storeModel)
        {
            var existingStore = await _context.Store.FindAsync(id);

            if (existingStore == null)
            {
                return null;
            }

            existingStore.Name = storeModel.Name;
            existingStore.Email = storeModel.Email;
            existingStore.PhoneNumber = storeModel.PhoneNumber;
            existingStore.Address = storeModel.Address;
            existingStore.CoverPhoto = storeModel.CoverPhoto;
            existingStore.ProfilePhoto = storeModel.ProfilePhoto;

            await _context.SaveChangesAsync();
            return existingStore;
        }
    }
}
