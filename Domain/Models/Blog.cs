using Domain.Enums;

namespace Domain.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
