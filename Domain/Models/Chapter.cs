namespace Domain.Models
{
    public class Chapter : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Research Research { get; set; }
        public int ResearchId { get; set; }
    }
}
