namespace Domain.Models
{
    public class Contact : BaseEntity
    { 
        public string Address { get; set; }
        public string Email { get; set; }
        public long CallNumber { get; set; }
    }
}
