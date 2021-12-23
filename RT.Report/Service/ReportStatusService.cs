using Microsoft.EntityFrameworkCore;
using RT.Reports.DataLayer;
using RT.Reports.Domain.Interfaces;
using System.Linq;

namespace RT.Reports.Service
{
    public class ReportStatusService : IReportStatus
    {
        private readonly RTReportsDataContext _dbContext;

        public ReportStatusService(RTReportsDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(ReportStatus entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ReportStatus entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<ReportStatus> GetAll()
        {
            return _dbContext.ReportStatuses.AsQueryable();
        }

        public IQueryable<ReportStatus> GetAllAsNoTracking()
        {
            return _dbContext.ReportStatuses.AsNoTracking().AsQueryable();
        }

        public ReportStatus GetByID(int id)
        {
            return _dbContext.ReportStatuses.FirstOrDefault(w => w.Id == id);
        }

        public void Update(ReportStatus entity)
        {
            _dbContext.ReportStatuses.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
