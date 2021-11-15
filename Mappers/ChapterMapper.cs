using Domain.Models;
using DTOs.ChapterDtos;

namespace Mappers
{
    public static class ChapterMapper
    {
        public static Chapter ToChapter(this CreateChapterDto createChapterDto)
        {
            return new Chapter()
            {
                Title = createChapterDto.Title,
                Content = createChapterDto.Content,
                ResearchId = createChapterDto.ResearchId
            };
        }

        public static Chapter ToChapter(this EditChapterDto editChapterDto)
        {
            return new Chapter()
            {
                Title = editChapterDto.Title,
                Content = editChapterDto.Content,
                ResearchId = editChapterDto.ResearchId
            };
        }
    }
}
