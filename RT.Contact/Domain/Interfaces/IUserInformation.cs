using RT.Contacts.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.Domain.Interfaces
{
    public interface IUserInformation
    {
        IQueryable<UserInformation> GetAll();
        IQueryable<UserInformation> GetAllAsNoTracking();
        UserInformation GetByID(int id);
        void Create(UserInformation entity);
        void Update(UserInformation entity);
        void Delete(UserInformation entity);
    }
}
