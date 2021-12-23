using RT.Contact.Domain.Models;
using RT.Contact.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Domain.Interfaces
{
    public interface ICityBL
    {
        Result<List<CityDO>> GetAll();
        Result<CityDO> GetByID(int id);
        Result<CityDO> Add(CityDO model);
        Result<CityDO> Update(CityDO model);
        Result<CityDO> Delete(CityDO model);
    }
}
