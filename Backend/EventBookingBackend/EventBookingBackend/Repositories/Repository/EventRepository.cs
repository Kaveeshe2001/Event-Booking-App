using EventBookingBackend.Data;
using EventBookingBackend.Helpers;
using EventBookingBackend.Models;
using EventBookingBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventBookingBackend.Repositories.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> CreateAsync(Event eventModel)
        {
            await _context.Event.AddAsync(eventModel);
            await _context.SaveChangesAsync();
            return eventModel;
        }
        
        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Event.FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task<List<Event?>> GetByCategoryAsync(int id)
        {
            return await _context.Event.Where(e => e.CategoryId == id).ToListAsync();
        }

        public async Task<List<Event?>> GetByStoreAsync(int id, QueryObject? query = null)
        {
            if(query != null)
            {
                var skipNumber = (query.PageNumber - 1) * query.PageSize;
                return await _context.Event.Where(e => e.StoreId == id).Skip(skipNumber).Take(query.PageSize).ToListAsync();
            }
            else
            {
                return await _context.Event.Where(e => e.StoreId == id).ToListAsync();
            }
        }

        public async Task<Event?> DeleteAsync(int id)
        {
            var eventModel = await _context.Event.FirstOrDefaultAsync(x => x.Id == id);

            if (eventModel == null)
            {
                return null;
            }

            _context.Event.Remove(eventModel);
            await _context.SaveChangesAsync();
            return eventModel;
        }

        public async Task<Event?> UpdateAsync(int id, Event eventModel)
        {
            var existingEvent = await _context.Event.FindAsync(id);

            if (existingEvent == null)
            {
                return null;
            }

            existingEvent.EventName = eventModel.EventName;
            existingEvent.Image = eventModel.Image;
            existingEvent.Description = eventModel.Description;
            existingEvent.TicketPrice = eventModel.TicketPrice;
            existingEvent.Location = eventModel.Location;
            existingEvent.Date = eventModel.Date;
            existingEvent.Time = eventModel.Time;
            existingEvent.Capacity = eventModel.Capacity;
            existingEvent.StoreId = eventModel.StoreId;
            existingEvent.CategoryId = eventModel.CategoryId;

            await _context.SaveChangesAsync();
            return existingEvent;
        }
        
        public async Task<int> CountAsync(int id)
        {
            return await _context.Event.CountAsync(e => e.StoreId == id);
        }
    }
}
