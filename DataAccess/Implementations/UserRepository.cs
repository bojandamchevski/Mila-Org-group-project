using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class UserRepository : IPersonRepository<User>
    {
        private AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(User entity)
        {
            _appDbContext.Users.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _appDbContext.Users
                .Include(x => x.UserTrainings)
                .ToList();
        }

        public User GetById(int id)
        {
            return _appDbContext.Users
                .Include(x => x.UserTrainings)
                .FirstOrDefault(x => x.Id == id);
        }

        public User GetPersonByEmail(string email)
        {
            return _appDbContext.Users
                .Include(x => x.UserTrainings)
                .FirstOrDefault(x => x.Email == email);
        }

        public void Insert(User entity)
        {
            _appDbContext.Users.Add(entity);
            _appDbContext.SaveChanges();
        }

        public User LoginPerson(string email, string password)
        {
            return _appDbContext.Users
                .Include(x => x.UserTrainings)
                .FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void Update(User entity)
        {
            _appDbContext.Users.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
