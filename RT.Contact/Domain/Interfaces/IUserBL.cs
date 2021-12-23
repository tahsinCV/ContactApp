using RT.Contacts.Domain.Models;
using RT.Contacts.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.Domain.Interfaces
{
    public interface IUserBL
    {

        Result<List<UserDO>> GetAll();
        Result<UserDO> GetByID(int id);
        Result<UserDO> Add(UserDO model);
        Result<UserDO> Update(UserDO model);
        Result<bool> Delete(int id);
    }
}
