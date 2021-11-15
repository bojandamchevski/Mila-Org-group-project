using DataAccess.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class ResearchRepository : IRepository<Research>
    {
        private AppDbContext _appDbContext;

        public ResearchRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(Research entity)
        {
            _appDbContext.Researches.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Research> GetAll()
        {
            return _appDbContext
                .Researches
                .ToList();
        }

        public Research GetById(int id)
        {
            return _appDbContext
                .Researches
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Research entity)
        {
            _appDbContext.Researches.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Research entity)
        {
            _appDbContext.Researches.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
