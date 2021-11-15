using DTOs.BlogDtos;

namespace Services.Interfaces
{
    public interface IBlogService
    {
        void CreateBlog(CreateBlogDto createBlogDto);
        void EditBlog(EditBlogDto editBlogDto);
        void DeleteBlog(int id);
    }
}
