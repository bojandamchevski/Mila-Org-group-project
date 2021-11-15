using DTOs.LoginDto;
using DTOs.RegisterDto;
using DTOs.RoleDto;

namespace Services.Interfaces
{
    public interface ITrainerService
    {
        void Register(RegisterDto registerUserDto);
        string Login(LoginDto loginDto);
        RoleDto CheckUserBeforeLogin(LoginDto loginDto);
    }
}
