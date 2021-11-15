using System.Collections.Generic;

namespace Domain.Models
{
    public class Research : BaseEntity
    {
        public string Title { get; set; }
        public List<Chapter> Chapters { get; set; }

        public Research()
        {
            Chapters = new List<Chapter>();
        }
    }
}
