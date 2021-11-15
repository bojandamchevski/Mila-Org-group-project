using DTOs.AdminFunctionalitiesDtos;
using DTOs.LoginDto;
using DTOs.RegisterDto;
using DTOs.RoleDto;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAdminService
    {
        void Register(RegisterDto registerUserDto);
        string Login(LoginDto loginDto);
        RoleDto CheckUserBeforeLogin(LoginDto loginDto);
        List<UserListDto> GetAllUsers();
        UserDetailsDto GetUserById(int id);
        List<TrainerListDto> GetAllTrainers();
        TrainerDetailsDto GetTrainerById(int id);
    }
}
