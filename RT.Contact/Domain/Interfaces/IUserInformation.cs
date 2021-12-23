using RT.Contact.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Domain.Interfaces
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
