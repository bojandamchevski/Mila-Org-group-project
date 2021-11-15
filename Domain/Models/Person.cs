using Domain.Enums;
using System;

namespace Domain.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public RoleEnum Role { get; set; }
        public GenderEnum? Gender { get; set; }
    }
}
