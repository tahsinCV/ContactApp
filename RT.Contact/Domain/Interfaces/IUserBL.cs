using RT.Contact.Domain.Models;
using RT.Contact.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Domain.Interfaces
{
    public interface IUserBL
    {

        Result<List<UserDO>> GetAll();
        Result<UserDO> GetByID(int id);
        Result<UserDO> Add(UserDO model);
        Result<UserDO> Update(UserDO model);
        Result<UserDO> Delete(UserDO model);
    }
}
