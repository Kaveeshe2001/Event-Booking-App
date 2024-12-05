using EventBookingBackend.Data;
using EventBookingBackend.Mappers;
using EventBookingBackend.Models.DTO.Category;
using EventBookingBackend.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ApplicationDbContext context, ICategoryRepository categoryRepo)
        {
            _context = context;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoryDto = categories.Select(s => s.ToCategoryDto());
            return Ok(categoryDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreate();
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryModel = await _categoryRepo.DeleteAsync(id);
            if(categoryModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCategoryDto categoryDto)
        {
            var categoryModel = await _categoryRepo.UpdateAsync(id, categoryDto.ToCategoryFromUpdate());
            if(categoryModel == null)
            {
                return NotFound();
            }
            return Ok(categoryModel.ToCategoryDto);
        }
    }
}
