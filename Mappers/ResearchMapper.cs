using Domain.Models;
using DTOs.ResearchDtos;

namespace Mappers
{
    public static class ResearchMapper
    {
        public static Research ToResearch(this CreateResearchDto createResearchDto)
        {
            return new Research()
            {
                Title = createResearchDto.Title
            };
        }

        public static Research ToResearch(this EditResearchDto editResearchDto)
        {
            return new Research()
            {
                Title = editResearchDto.Title
            };
        }
    }
}
