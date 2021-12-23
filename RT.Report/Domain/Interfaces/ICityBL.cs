using RT.Reports.Domain.Models;
using RT.Reports.ResultType;
using System.Collections.Generic;

namespace RT.Reports.Domain.Interfaces
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
