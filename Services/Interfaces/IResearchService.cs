using DTOs.ResearchDtos;

namespace Services.Interfaces
{
    public interface IResearchService
    {
        void CreateResearch(CreateResearchDto createResearchDto);
        void EditResearch(EditResearchDto editResearchDto);
        void DeleteResearch(int id);
    }
}
