using Microsoft.EntityFrameworkCore;
using RT.Reports.DataLayer;
using RT.Reports.Domain.Interfaces;
using System.Linq;

namespace RT.Reports.Service
{
    public class ReportService : IReport
    {
        private readonly RTReportsDataContext _dbContext;

        public ReportService(RTReportsDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(DataLayer.Report entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(DataLayer.Report entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<DataLayer.Report> GetAll()
        {
            return _dbContext.Reports.AsQueryable();
        }

        public IQueryable<DataLayer.Report> GetAllAsNoTracking()
        {
            return _dbContext.Reports.AsNoTracking().AsQueryable();
        }

        public DataLayer.Report GetByID(int id)
        {
            return _dbContext.Reports.FirstOrDefault(w => w.Id == id);
        }

        public void Update(DataLayer.Report entity)
        {
            _dbContext.Reports.Update(entity);
        }
    }
}
