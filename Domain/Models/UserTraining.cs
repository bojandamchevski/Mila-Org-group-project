namespace Domain.Models
{
    public class UserTraining : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
