using RT.Reports.Domain.Models;
using RT.Reports.ResultType;
using System.Collections.Generic;

namespace RT.Reports.Domain.Interfaces
{
    public interface IReportBL
    {
        Result<List<ReportDO>> GetAll();
        Result<ReportDO> GetByID(int id);
        Result<ReportDO> Add(ReportDO model);
        Result<ReportDO> Update(ReportDO model);
        Result<ReportDO> Delete(ReportDO model);
    }
}
