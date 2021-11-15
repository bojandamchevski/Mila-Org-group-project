using Domain.Models;
using DTOs.AdminFunctionalitiesDtos;
using System.Linq;

namespace Mappers
{
    public static class AdminFunctionalitiesMapper
    {
        public static TrainerDetailsDto ToTrainerDetailsDto(this Trainer trainer)
        {
            return new TrainerDetailsDto()
            {
                Id = trainer.Id,
                DateOfBirth = trainer.DateOfBirth,
                Email = trainer.Email,
                FirstName = trainer.FirstName,
                Gender = (int)trainer.Gender,
                LastName = trainer.LastName,
                Password = trainer.Password,
                Role = (int)trainer.Role,
                Trainings = trainer.Trainings.Select(x => x.ToTrainingListDto()).ToList()
            };
        }

        public static TrainerListDto ToTrainerListDto(this Trainer trainer)
        {
            return new TrainerListDto()
            {
                Id = trainer.Id,
                Email = trainer.Email,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName
            };
        }

        public static TrainingListDto ToTrainingListDto(this Training training)
        {
            return new TrainingListDto()
            {
                Id = training.Id,
                Date = training.Date,
                NumberOfTotalSpots = training.NumberOfTotalSpots,
                NumberOfSpotsRemaining = training.NumberOfSpotsRemaining,
                NumberOfTakenSpots = training.NumberOfTakenSpots,
                Title = training.Title
            };
        }

        public static UserDetailsDto ToUserDetailsDto(this User user)
        {
            return new UserDetailsDto()
            {
                Id = user.Id,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = (int)user.Gender,
                LastName = user.LastName,
                Password = user.Password,
                Role = (int)user.Role
            };
        }

        public static UserListDto ToUserListDto(this User user)
        {
            return new UserListDto()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
