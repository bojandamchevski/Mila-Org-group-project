using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class BlogRepository : IRepository<Blog>
    {
        private AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(Blog entity)
        {
            _appDbContext.Blogs.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            return _appDbContext
                .Blogs
                .Include(x => x.Category)
                .ToList();
        }

        public Blog GetById(int id)
        {
            return _appDbContext
                .Blogs
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Blog entity)
        {
            _appDbContext.Blogs.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Blog entity)
        {
            _appDbContext.Blogs.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}