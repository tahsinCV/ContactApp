using RT.Reports.DataLayer;
using System.Linq;

namespace RT.Reports.Domain.Interfaces
{
    public interface IReportStatus
    {

        IQueryable<ReportStatus> GetAll();
        IQueryable<ReportStatus> GetAllAsNoTracking();
        ReportStatus GetByID(int id);
        void Create(ReportStatus entity);
        void Update(ReportStatus entity);
        void Delete(ReportStatus entity);
    }
}
