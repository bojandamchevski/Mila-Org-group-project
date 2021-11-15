using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class User : Person
    {
        public List<UserTraining> UserTrainings { get; set; }

        public User()
        {
            Role = RoleEnum.User;
            UserTrainings = new List<UserTraining>();
        }
    }
}
