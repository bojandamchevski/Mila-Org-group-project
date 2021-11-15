using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Trainer : Person
    {
        public List<Training> Trainings { get; set; }
        public Trainer()
        {
            Role = RoleEnum.Trainer;
            Trainings = new List<Training>();
        }
    }
}
