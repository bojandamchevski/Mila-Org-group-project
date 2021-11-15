using DataAccess.Interfaces;
using Domain.Models;
using DTOs.CategoryDtos;
using Mappers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category newCategory = createCategoryDto.ToCategory();
            _categoryRepository.Insert(newCategory);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(_categoryRepository.GetById(id));
        }

        public void EditCategory(EditCategoryDto editCategoryDto)
        {
            Category editedCategory = editCategoryDto.ToCategory();
            _categoryRepository.Update(editedCategory);
        }
    }
}
