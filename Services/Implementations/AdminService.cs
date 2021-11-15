using DataAccess.Interfaces;
using Domain.Models;
using DTOs.AdminFunctionalitiesDtos;
using DTOs.LoginDto;
using DTOs.RegisterDto;
using DTOs.RoleDto;
using Mappers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Shared;
using Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Implementations
{
    public class AdminService : IAdminService
    {
        private IPersonRepository<Admin> _adminRepository;
        private IPersonRepository<User> _userRepository;
        private IPersonRepository<Trainer> _trainerRepository;
        IOptions<AppSettings> _options;

        public AdminService(IPersonRepository<Admin> adminRepository, IOptions<AppSettings> options, IPersonRepository<User> userRepository, IPersonRepository<Trainer> trainerRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _trainerRepository = trainerRepository;
            _options = options;
        }

        public void Register(RegisterDto registerAdminDto)
        {
            ValidateUser(registerAdminDto);

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerAdminDto.Password);
            byte[] passwordHash = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hashedPasword = Encoding.ASCII.GetString(passwordHash);

            Admin newAdmin = registerAdminDto.ToAdmin();
            newAdmin.Password = hashedPasword;
            _adminRepository.Insert(newAdmin);
        }
        public string Login(LoginDto loginDto)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(loginDto.Password));
            string hashedPassword = Encoding.ASCII.GetString(hashedBytes);

            Admin adminDb = _adminRepository.LoginPerson(loginDto.Email, hashedPassword);
            if (adminDb == null)
            {
                throw new ResourceNotFoundException($"Could not login admin {loginDto.Email}");
            }

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(
                    new[]
                   {
                        new Claim(ClaimTypes.Name, adminDb.Email),
                        new Claim(ClaimTypes.NameIdentifier, adminDb.Id.ToString()),
                        new Claim("adminFullName", $"{adminDb.FirstName} {adminDb.LastName}"),
                        new Claim(ClaimTypes.Role, "1") //Tuka moze da se napravi problem
                    }
                )
            };
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }

        private void ValidateUser(RegisterDto registerAdminDto)
        {
            if (string.IsNullOrEmpty(registerAdminDto.Email) || string.IsNullOrEmpty(registerAdminDto.Password))
            {
                throw new PersonException("Email and password are required fields!");
            }
            if (string.IsNullOrEmpty(registerAdminDto.Role.ToString()))
            {
                throw new PersonException("Role is a required field!");
            }
            if (registerAdminDto.Email.Length > 50)
            {
                throw new PersonException("Email can contain maximum 30 characters!");
            }
            if (registerAdminDto.FirstName.Length > 50 || registerAdminDto.LastName.Length > 50)
            {
                throw new PersonException("Firstname and Lastname can contain maximum 50 characters!");
            }
            if (!IsUserNameUnique(registerAdminDto.Email))
            {
                throw new PersonException("A user with this email already exists!");
            }
            if (registerAdminDto.Password != registerAdminDto.ConfirmedPassword)
            {
                throw new PersonException("The passwords do not match!");
            }
            if (!IsPasswordValid(registerAdminDto.Password))
            {
                throw new PersonException("The password is not complex enough!");
            }
        }

        private bool IsUserNameUnique(string email)
        {
            return _adminRepository.GetPersonByEmail(email) == null;
        }

        private bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            return passwordRegex.Match(password).Success;
        }

        public RoleDto CheckUserBeforeLogin(LoginDto loginDto)
        {
            Admin adminDb = _adminRepository.GetPersonByEmail(loginDto.Email);

            if (adminDb != null)
                return new RoleDto() { Role = 1 };
            return null;
        }

        public List<UserListDto> GetAllUsers()
        {
            return _userRepository.GetAll().Select(x=>x.ToUserListDto()).ToList();
        }

        public UserDetailsDto GetUserById(int id)
        {
            return _userRepository.GetById(id).ToUserDetailsDto();
        }

        public List<TrainerListDto> GetAllTrainers()
        {
            return _trainerRepository.GetAll().Select(x => x.ToTrainerListDto()).ToList();
        }

        public TrainerDetailsDto GetTrainerById(int id)
        {
            return _trainerRepository.GetById(id).ToTrainerDetailsDto();
        }
    }
}
