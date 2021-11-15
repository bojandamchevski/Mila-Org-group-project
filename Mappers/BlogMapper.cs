using Domain.Models;
using DTOs.BlogDtos;

namespace Mappers
{
    public static class BlogMapper
    {
        public static Blog ToBlog(this CreateBlogDto createBlogDto)
        {
            return new Blog()
            {
                Title = createBlogDto.Title,
                Content = createBlogDto.Content,
                ImgURL = createBlogDto.ImgURL,
                CategoryId = createBlogDto.CategoryId
            };
        }

        public static Blog ToBlog(this EditBlogDto editBlogDto)
        {
            return new Blog()
            {
                Title = editBlogDto.Title,
                Content = editBlogDto.Content,
                ImgURL = editBlogDto.ImgURL,
                CategoryId = editBlogDto.CategoryId
            };
        }
    }
}
