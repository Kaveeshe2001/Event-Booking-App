using EventBookingBackend.Models;
using EventBookingBackend.Models.DTO.Category;

namespace EventBookingBackend.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category categorymodel) 
        {
            return new CategoryDto
            {
                Id = categorymodel.Id,
                CategoryName = categorymodel.CategoryName,
                Image = categorymodel.Image,
            };
        }

        public static Category ToCategoryFromCreate(this CreateCategoryDto createCategoryDto)
        {
            return new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                Image = createCategoryDto.Image,
            };
        }

        public static Category ToCategoryFromUpdate(this UpdateCategoryDto updateCategoryDto)
        {
            return new Category
            {
                CategoryName = updateCategoryDto.CategoryName,
                Image = updateCategoryDto.Image,
            };
        }
    }
}
