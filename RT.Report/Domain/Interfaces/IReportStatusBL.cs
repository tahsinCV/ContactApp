using RT.Reports.Domain.Models;
using RT.Reports.ResultType;
using System.Collections.Generic;

namespace RT.Reports.Domain.Interfaces
{
    public interface IReportStatusBL
    {
        Result<List<ReportStatusDO>> GetAll();
        Result<ReportStatusDO> GetByID(int id);
        Result<ReportStatusDO> Add(ReportStatusDO model);
        Result<ReportStatusDO> Update(ReportStatusDO model);
        Result<ReportStatusDO> Delete(ReportStatusDO model);
    }
}
