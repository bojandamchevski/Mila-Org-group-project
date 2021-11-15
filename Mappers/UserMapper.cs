using Domain.Enums;
using Domain.Models;
using DTOs.RegisterDto;
using System;

namespace Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this RegisterDto registerUserDto)
        {
            return new User()
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                DateOfBirth = DateTime.Parse(registerUserDto.DateOfBirth),
                Email = registerUserDto.Email,
                Password = registerUserDto.Password,
                Gender = (GenderEnum)registerUserDto.Gender,
                Role = (RoleEnum)registerUserDto.Role
            };
        }
    }
}