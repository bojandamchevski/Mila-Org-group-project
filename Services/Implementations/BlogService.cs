using DataAccess.Interfaces;
using Domain.Models;
using DTOs.BlogDtos;
using Mappers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class BlogService : IBlogService
    {
        private IRepository<Blog> _blogRepository;
        private IRepository<Category> _categoryRepository;
        public BlogService(IRepository<Blog> blogRepository, IRepository<Category> categoryRepository)
        {
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
        }

        public void CreateBlog(CreateBlogDto createBlogDto)
        {
            Blog newBlog = createBlogDto.ToBlog();
            Category categoryDb = _categoryRepository.GetById(createBlogDto.CategoryId);
            if(categoryDb == null)
            {
                Category newCategory = new Category();
                _categoryRepository.Insert(newCategory);
                newBlog.Category = newCategory;
                newCategory.Blogs.Add(newBlog);
                _categoryRepository.Update(newCategory);
                _blogRepository.Insert(newBlog);
            }
            newBlog.Category = categoryDb;
            categoryDb.Blogs.Add(newBlog);
            _categoryRepository.Update(categoryDb);
            _blogRepository.Insert(newBlog);
        }

        public void DeleteBlog(int id)
        {
            _blogRepository.Delete(_blogRepository.GetById(id));
        }

        public void EditBlog(EditBlogDto editBlogDto)
        {
            Blog editedBlog = editBlogDto.ToBlog();
            editedBlog.Category = _categoryRepository.GetById(editedBlog.CategoryId);
            _blogRepository.Update(editedBlog);
        }
    }
}
