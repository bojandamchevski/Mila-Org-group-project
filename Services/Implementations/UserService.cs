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
    public class UserService : IUserService
    {
        private IPersonRepository<User> _userRepository;
        private IRepository<Training> _trainingRepository;
        private IRepository<UserTraining> _userTrainingRepository;
        IOptions<AppSettings> _options;

        public UserService(IPersonRepository<User> userRepository, IOptions<AppSettings> options, IRepository<Training> trainingRepository, IRepository<UserTraining> userTrainingRepository)
        {
            _userRepository = userRepository;
            _trainingRepository = trainingRepository;
            _userTrainingRepository = userTrainingRepository;
            _options = options;
        }

        public void Register(RegisterDto registerUserDto)
        {
            ValidateUser(registerUserDto);

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerUserDto.Password);
            //byte[] confirmPasswordBytes = Encoding.ASCII.GetBytes(registerUserDto.ConfirmedPassword);
            byte[] passwordHash = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hashedPasword = Encoding.ASCII.GetString(passwordHash);

            User newUser = registerUserDto.ToUser();
            newUser.Password = hashedPasword;
            _userRepository.Insert(newUser);
        }
        public string Login(LoginDto loginDto)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(loginDto.Password));
            string hashedPassword = Encoding.ASCII.GetString(hashedBytes);

            User userDb = _userRepository.LoginPerson(loginDto.Email, hashedPassword);
            if (userDb == null)
            {
                throw new ResourceNotFoundException($"Could not login user {loginDto.Email}");
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
                        new Claim(ClaimTypes.Name, userDb.Email),
                        new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                        new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}"),
                        new Claim(ClaimTypes.Role, "2") //Tuka moze da se napravi problem
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
            return _userRepository.GetPersonByEmail(email) == null;
        }

        private bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            return passwordRegex.Match(password).Success;
        }

        public RoleDto CheckUserBeforeLogin(LoginDto loginDto)
        {
            User userDb = _userRepository.GetPersonByEmail(loginDto.Email);

            if (userDb != null)
                return new RoleDto() { Role = 2 };
            return null;
        }

        public void TakeTraining(int trainingId, int userId)
        {
            Training trainingDb = _trainingRepository.GetById(trainingId);
            User userDb = _userRepository.GetById(userId);
            UserTraining newUserTraining = new UserTraining()
            {
                Training = trainingDb,
                TrainingId = trainingDb.Id,
                User = userDb,
                UserId = userDb.Id
            };

            ++trainingDb.NumberOfTakenSpots;

            trainingDb.UserTrainings.Add(newUserTraining);
            userDb.UserTrainings.Add(newUserTraining);

            _userTrainingRepository.Insert(newUserTraining);
            _userRepository.Update(userDb);
            _trainingRepository.Update(trainingDb);
        }
    }
}
