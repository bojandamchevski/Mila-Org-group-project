using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class UserTrainingRepository : IRepository<UserTraining>
    {
        private AppDbContext _appDbContext;

        public UserTrainingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Delete(UserTraining entity)
        {
            _appDbContext.UserTrainings.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<UserTraining> GetAll()
        {
            return _appDbContext
                .UserTrainings
                .Include(x => x.Training)
                .ToList();
        }

        public UserTraining GetById(int id)
        {
            return _appDbContext
                .UserTrainings
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(UserTraining entity)
        {
            _appDbContext.UserTrainings.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(UserTraining entity)
        {
            _appDbContext.UserTrainings.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
