using RT.Contact.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Domain.Interfaces
{
    public interface IUser
    {
        IQueryable<User> GetAll();
        IQueryable<User> GetAllAsNoTracking();
        User GetByID(int id);
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
