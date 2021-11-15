using DataAccess.Interfaces;
using Domain.Models;
using DTOs.ChapterDtos;
using Mappers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ChapterService : IChapterService
    {
        private IRepository<Chapter> _chapterRepository;
        private IRepository<Research> _researchRepository;

        public ChapterService(IRepository<Chapter> chapterRepository, IRepository<Research> researchRepository)
        {
            _chapterRepository = chapterRepository;
            _researchRepository = researchRepository;
        }

        public void CreateChapter(CreateChapterDto createChapterDto)
        {
            Chapter newChapter = createChapterDto.ToChapter();
            Research researchDb = _researchRepository.GetById(newChapter.ResearchId);

            newChapter.Research = researchDb;
            researchDb.Chapters.Add(newChapter);

            _chapterRepository.Insert(newChapter);
            _researchRepository.Update(researchDb);
        }

        public void DeleteChapter(int id)
        {
            _chapterRepository.Delete(_chapterRepository.GetById(id));
        }

        public void EditChapter(EditChapterDto editChapterDto)
        {
            Chapter editedChapter = editChapterDto.ToChapter();
            Research researchDb = _researchRepository.GetById(editChapterDto.ResearchId);

            editedChapter.Research = researchDb;

            _chapterRepository.Update(editedChapter);
        }
    }
}
