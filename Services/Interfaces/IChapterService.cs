using DTOs.ChapterDtos;

namespace Services.Interfaces
{
    public interface IChapterService
    {
        void CreateChapter(CreateChapterDto createChapterDto);
        void EditChapter(EditChapterDto editChapterDto);
        void DeleteChapter(int id);
    }
}
