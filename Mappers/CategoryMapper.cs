using Domain.Models;
using DTOs.CategoryDtos;

namespace Mappers
{
    public static class CategoryMapper
    {
        public static Category ToCategory(this CreateCategoryDto createCategoryDto)
        {
            return new Category()
            {
                CategoryName = createCategoryDto.CategoryName
            };
        }

        public static Category ToCategory(this EditCategoryDto editCategoryDto)
        {
            return new Category()
            {
                CategoryName = editCategoryDto.CategoryName
            };
        }
    }
}
