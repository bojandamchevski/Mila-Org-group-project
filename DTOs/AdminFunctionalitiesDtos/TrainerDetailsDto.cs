using System;
using System.Collections.Generic;

namespace DTOs.AdminFunctionalitiesDtos
{
    public class TrainerDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Role { get; set; }
        public int Gender { get; set; }
        public List<TrainingListDto> Trainings { get; set; }
    }
}
