using Microsoft.EntityFrameworkCore;
using RT.Contacts.DataLayer;
using RT.Contacts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.Service
{
    public class UserService : IUser
    {
        private readonly RTDataContext _dbContext;

        public UserService(RTDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(User entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users.AsQueryable();
        }

        public IQueryable<User> GetAllAsNoTracking()
        {
            return _dbContext.Users.AsNoTracking().AsQueryable();
        }

        public User GetByID(int id)
        {
            return _dbContext.Users.FirstOrDefault(w => w.Id == id);
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
        }
    }
}
