using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class TrainerRepository : IPersonRepository<Trainer>
    {
        private AppDbContext _appDbContext;

        public TrainerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(Trainer entity)
        {
            _appDbContext.Trainers.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Trainer> GetAll()
        {
            return _appDbContext.Trainers
                .Include(x=>x.Trainings)
                .ToList();
        }

        public Trainer GetById(int id)
        {
            return _appDbContext.Trainers
                .Include(x => x.Trainings)
                .FirstOrDefault(x => x.Id == id);
        }

        public Trainer GetPersonByEmail(string email)
        {
            return _appDbContext.Trainers
                .Include(x => x.Trainings)
                .FirstOrDefault(x => x.Email == email);
        }

        public void Insert(Trainer entity)
        {
            _appDbContext.Trainers.Add(entity);
            _appDbContext.SaveChanges();
        }

        public Trainer LoginPerson(string email, string password)
        {
            return _appDbContext.Trainers
                .Include(x => x.Trainings)
                .FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void Update(Trainer entity)
        {
            _appDbContext.Trainers.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
