using EventBookingBackend.Data;
using EventBookingBackend.Extentions;
using EventBookingBackend.Helpers;
using EventBookingBackend.Mappers;
using EventBookingBackend.Models;
using EventBookingBackend.Models.DTO.Event;
using EventBookingBackend.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventRepository _eventRepo;
        private readonly ILogger _logger;
        private readonly IStoreRepository _storeRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(ApplicationDbContext context, IEventRepository eventRepo, ILogger logger, IStoreRepository storeRepo, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _eventRepo = eventRepo;
            _logger = logger;
            _storeRepo = storeRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventRepo.GetAllAsync();
            var eventDto = events.Select(s => s.ToEventDto());
            return Ok(eventDto);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var events = await _eventRepo.GetByIdAsync(id);

            if(events == null)
            {
                return NotFound();
            }

            return Ok(events.ToEventDto);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategory([FromRoute] int id)
        {
            var events = await _eventRepo.GetByCategoryAsync(id);
            var eventDto = events.Select(s => s.ToEventDto());
            return Ok(eventDto);
        }

        [HttpGet("store/{id}")]
        public async Task<IActionResult> GetByStore([FromRoute] int id, [FromQuery] QueryObject query)
        {
            List<Event?> events;

            if (query != null)
            {
                events = await _eventRepo.GetByStoreAsync(id, query);
            }
            else
            {
                events = await _eventRepo.GetByStoreAsync(id);
            }

            var eventDto = events.Select(s => s.ToEventDto());
            var totalEventCount = await _eventRepo.CountAsync(id);

            return Ok(new
            {
                TotalCount = totalEventCount,
                Events = eventDto,
            });

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateEventDto eventDto)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("User cannot be found");
            }

            var store = await _context.Store
                .Where(x => x.UserId.ToLower() == user.Id.ToLower())
                .FirstOrDefaultAsync();

            if (store == null)
            {
                return NotFound("Create a Store first");
            }

            try
            {
                var eventModel = eventDto.ToEventFromCreate(store.Id);
                await _eventRepo.CreateAsync(eventModel);
                return CreatedAtAction(nameof(GetById), new { id = eventModel.Id }, eventModel.ToEventDto());
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, "An error occurred while creating the art: " + errorMessage);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var eventModel = await _eventRepo.DeleteAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateEventDto eventDto)
        {
            var eventModel = await _eventRepo.UpdateAsync(id, eventDto.ToEventFromUpdate(id));

            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel.ToEventDto());
        }
    }
}
