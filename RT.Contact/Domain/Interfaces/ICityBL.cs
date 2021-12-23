using RT.Contacts.Domain.Models;
using RT.Contacts.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.Domain.Interfaces
{
    public interface ICityBL
    {
        Result<List<CityDO>> GetAll();
        Result<CityDO> GetByID(int id);
        Result<CityDO> Add(CityDO model);
        Result<CityDO> Update(CityDO model);
        Result<bool> Delete(int id);
    }
}
