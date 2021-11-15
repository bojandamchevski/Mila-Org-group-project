using DataAccess.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class AdminRepository : IPersonRepository<Admin>
    {
        private AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(Admin entity)
        {
            _appDbContext.Admins.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Admin> GetAll()
        {
            return _appDbContext.Admins.ToList();
        }

        public Admin GetById(int id)
        {
            return _appDbContext.Admins.FirstOrDefault(x => x.Id == id);
        }

        public Admin GetPersonByEmail(string email)
        {
            return _appDbContext.Admins.FirstOrDefault(x => x.Email == email);
        }

        public void Insert(Admin entity)
        {
            _appDbContext.Admins.Add(entity);
            _appDbContext.SaveChanges();
        }

        public Admin LoginPerson(string email, string password)
        {
            return _appDbContext.Admins.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void Update(Admin entity)
        {
            _appDbContext.Admins.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
