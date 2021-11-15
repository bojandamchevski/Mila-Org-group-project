using DataAccess.Interfaces;
using Domain.Models;
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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private IPersonRepository<Trainer> _trainerRepository;
        IOptions<AppSettings> _options;

        public TrainerService(IPersonRepository<Trainer> trainerRepository, IOptions<AppSettings> options)
        {
            _trainerRepository = trainerRepository;
            _options = options;
        }

        public void Register(RegisterDto registerTrainerDto)
        {
            ValidateUser(registerTrainerDto);

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerTrainerDto.Password);
            byte[] passwordHash = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hashedPasword = Encoding.ASCII.GetString(passwordHash);

            Trainer newTrainer = registerTrainerDto.ToTrainer();
            newTrainer.Password = hashedPasword;
            _trainerRepository.Insert(newTrainer);
        }
        public string Login(LoginDto loginDto)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(loginDto.Password));
            string hashedPassword = Encoding.ASCII.GetString(hashedBytes);

            Trainer trainerDb = _trainerRepository.LoginPerson(loginDto.Email, hashedPassword);
            if (trainerDb == null)
            {
                throw new ResourceNotFoundException($"Could not login trainer {loginDto.Email}");
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
                        new Claim(ClaimTypes.Name, trainerDb.Email),
                        new Claim(ClaimTypes.NameIdentifier, trainerDb.Id.ToString()),
                        new Claim("trainerFullName", $"{trainerDb.FirstName} {trainerDb.LastName}"),
                        new Claim(ClaimTypes.Role, "3") //Tuka moze da se napravi problem
                    }
                )
            };
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }

        private void ValidateUser(RegisterDto registerTrainerDto)
        {
            if (string.IsNullOrEmpty(registerTrainerDto.Email) || string.IsNullOrEmpty(registerTrainerDto.Password))
            {
                throw new PersonException("Email and password are required fields!");
            }
            if (string.IsNullOrEmpty(registerTrainerDto.Role.ToString()))
            {
                throw new PersonException("Role is a required field!");
            }
            if (registerTrainerDto.Email.Length > 50)
            {
                throw new PersonException("Email can contain maximum 30 characters!");
            }
            if (registerTrainerDto.FirstName.Length > 50 || registerTrainerDto.LastName.Length > 50)
            {
                throw new PersonException("Firstname and Lastname can contain maximum 50 characters!");
            }
            if (!IsUserNameUnique(registerTrainerDto.Email))
            {
                throw new PersonException("A user with this email already exists!");
            }
            if (registerTrainerDto.Password != registerTrainerDto.ConfirmedPassword)
            {
                throw new PersonException("The passwords do not match!");
            }
            if (!IsPasswordValid(registerTrainerDto.Password))
            {
                throw new PersonException("The password is not complex enough!");
            }
        }

        private bool IsUserNameUnique(string email)
        {
            return _trainerRepository.GetPersonByEmail(email) == null;
        }

        private bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            return passwordRegex.Match(password).Success;
        }

        public RoleDto CheckUserBeforeLogin(LoginDto loginDto)
        {
            Trainer trainerDb = _trainerRepository.GetPersonByEmail(loginDto.Email);

            if (trainerDb != null)
                return new RoleDto() { Role = 3 };
            return null;
        }
    }
}
