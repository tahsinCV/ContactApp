using RT.Contact.Domain.Models;
using RT.Contact.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Domain.Interfaces
{
    public interface IUserInformationBL
    {
        Result<List<UserInformationDO>> GetAll();
        Result<UserInformationDO> GetByID(int id);
        Result<UserInformationDO> Add(UserInformationDO model);
        Result<UserInformationDO> Update(UserInformationDO model);
        Result<UserInformationDO> Delete(UserInformationDO model);
    }
}
