using Domain.Enums;
using Domain.Models;
using DTOs.RegisterDto;
using System;

namespace Mappers
{
    public static class AdminMapper
    {
        public static Admin ToAdmin(this RegisterDto registerAdminDto)
        {
            return new Admin()
            {
                FirstName = registerAdminDto.FirstName,
                LastName = registerAdminDto.LastName,
                DateOfBirth = DateTime.Parse(registerAdminDto.DateOfBirth),
                Email = registerAdminDto.Email,
                Password = registerAdminDto.Password,
                Gender = (GenderEnum)registerAdminDto.Gender,
                Role = (RoleEnum)registerAdminDto.Role
            };
        }
    }
}
