using System.Linq;

namespace RT.Reports.Domain.Interfaces
{
    public interface IReport
    {
        IQueryable<DataLayer.Report> GetAll();
        IQueryable<DataLayer.Report> GetAllAsNoTracking();
        DataLayer.Report GetByID(int id);
        void Create(DataLayer.Report entity);
        void Update(DataLayer.Report entity);
        void Delete(DataLayer.Report entity);
    }
}
