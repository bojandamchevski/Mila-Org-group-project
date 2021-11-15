using DataAccess.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class ContactRepository : IRepository<Contact>
    {

        private AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(Contact entity)
        {
            _appDbContext.Contacts.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Contact> GetAll()
        {
            return _appDbContext
                .Contacts
                .ToList();
        }

        public Contact GetById(int id)
        {
            return _appDbContext
                .Contacts
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Contact entity)
        {
            _appDbContext.Contacts.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Contact entity)
        {
            _appDbContext.Contacts.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}