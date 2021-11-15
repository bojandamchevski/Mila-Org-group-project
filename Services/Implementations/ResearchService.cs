using DataAccess.Interfaces;
using Domain.Models;
using DTOs.ResearchDtos;
using Mappers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ResearchService : IResearchService
    {
        private IRepository<Research> _researchRepository;
        private IRepository<Chapter> _chapterRepository;

        public ResearchService(IRepository<Research> researchRepository, IRepository<Chapter> chapterRepository)
        {
            _researchRepository = researchRepository;
            _chapterRepository = chapterRepository;
        }
        public void CreateResearch(CreateResearchDto createResearchDto)
        {
            Research newResearch = createResearchDto.ToResearch();
            _researchRepository.Insert(newResearch);
        }

        public void DeleteResearch(int id)
        {
            _researchRepository.Delete(_researchRepository.GetById(id));
        }

        public void EditResearch(EditResearchDto editResearchDto)
        {
            Research editedResearch = editResearchDto.ToResearch();
            foreach (int id in editResearchDto.ChapterIds)
            {
                Chapter chapterDb = _chapterRepository.GetById(id);
                editedResearch.Chapters.Add(chapterDb);
                chapterDb.Research = editedResearch;
                chapterDb.ResearchId = editedResearch.Id;
                _chapterRepository.Update(chapterDb);
            }

            _researchRepository.Update(editedResearch);
        }
    }
}
