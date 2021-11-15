using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class TrainingRepository : IRepository<Training>
    {
        private AppDbContext _appDbContext;

        public TrainingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(Training entity)
        {
            _appDbContext.Trainings.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Training> GetAll()
        {
            return _appDbContext
            .Trainings
            .Include(x => x.Trainer)
            .ToList();
        }

        public Training GetById(int id)
        {
            return _appDbContext
            .Trainings
            .Include(x => x.Trainer)
            .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Training entity)
        {
            _appDbContext.Trainings.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Training entity)
        {
            _appDbContext.Trainings.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}