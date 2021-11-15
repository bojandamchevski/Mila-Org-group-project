using System;

namespace DTOs.RegisterDto
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string DateOfBirth { get; set; }
        public int Role { get; set; }
        public int? Gender { get; set; }
    }
}
