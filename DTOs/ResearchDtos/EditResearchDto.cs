using System.Collections.Generic;

namespace DTOs.ResearchDtos
{
    public class EditResearchDto
    {
        public string Title { get; set; }
        public List<int> ChapterIds { get; set; }
    }
}
