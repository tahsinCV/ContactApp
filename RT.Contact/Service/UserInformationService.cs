using Microsoft.EntityFrameworkCore;
using RT.Contact.DataLayer;
using RT.Contact.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Service
{
    public class UserInformationService : IUserInformation
    {
        private readonly RTDataContext _dbContext;

        public UserInformationService(RTDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(UserInformation entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(UserInformation entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<UserInformation> GetAll()
        {
            return _dbContext.UserInformations.AsQueryable();
        }

        public IQueryable<UserInformation> GetAllAsNoTracking()
        {
            return _dbContext.UserInformations.AsNoTracking().AsQueryable();
        }

        public UserInformation GetByID(int id)
        {
            return _dbContext.UserInformations.FirstOrDefault(w => w.Id == id);
        }

        public void Update(UserInformation entity)
        {
            _dbContext.UserInformations.Update(entity);
        }
    }
}
