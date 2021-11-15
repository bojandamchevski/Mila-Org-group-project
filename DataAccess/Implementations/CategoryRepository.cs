using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class CategoryRepository : IRepository<Category>
    {
        private AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Delete(Category entity)
        {
            _appDbContext.Categories.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _appDbContext
                .Categories
                .Include(x => x.Blogs)
                .ToList();
        }

        public Category GetById(int id)
        {
            return _appDbContext
                .Categories
                .Include(x => x.Blogs)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Category entity)
        {
            _appDbContext.Categories.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            _appDbContext.Categories.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}