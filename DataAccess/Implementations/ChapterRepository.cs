using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class ChapterRepository : IRepository<Chapter>
    {
        private AppDbContext _appDbContext;

        public ChapterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Delete(Chapter entity)
        {
            _appDbContext.Chapters.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Chapter> GetAll()
        {
            return _appDbContext
                .Chapters
                .Include(x => x.Research)
                .ToList();
        }

        public Chapter GetById(int id)
        {
            return _appDbContext
                 .Chapters
                 .Include(x => x.Research)
                 .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Chapter entity)
        {
            _appDbContext.Chapters.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Chapter entity)
        {
            _appDbContext.Chapters.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
