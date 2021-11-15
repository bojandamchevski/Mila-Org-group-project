using System.Collections.Generic;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
