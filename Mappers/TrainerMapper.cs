using Domain.Enums;
using Domain.Models;
using DTOs.RegisterDto;
using System;

namespace Mappers
{
    public static class TrainerMapper
    {
        public static Trainer ToTrainer(this RegisterDto registerTrainerDto)
        {
            return new Trainer()
            {
                FirstName = registerTrainerDto.FirstName,
                LastName = registerTrainerDto.LastName,
                DateOfBirth = DateTime.Parse(registerTrainerDto.DateOfBirth),
                Email = registerTrainerDto.Email,
                Password = registerTrainerDto.Password,
                Gender = (GenderEnum)registerTrainerDto.Gender,
                Role = (RoleEnum)registerTrainerDto.Role
            };
        }
    }
}
