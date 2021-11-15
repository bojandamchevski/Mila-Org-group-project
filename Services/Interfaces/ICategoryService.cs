using DTOs.CategoryDtos;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CreateCategoryDto createCategoryDto);
        void EditCategory(EditCategoryDto editCategoryDto);
        void DeleteCategory(int id);
    }
}
