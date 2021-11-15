using Domain.Enums;

namespace Domain.Models
{
    public class Admin : Person
    {
        public Admin()
        {
            Role = RoleEnum.Admin;
        }
    }
}
