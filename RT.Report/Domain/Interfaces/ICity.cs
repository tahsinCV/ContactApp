using RT.Reports.DataLayer;
using System.Linq;

namespace RT.Reports.Domain.Interfaces
{
    public interface ICity
    {
        IQueryable<City> GetAll();
        IQueryable<City> GetAllAsNoTracking();
        City GetByID(int id);
        void Create(City entity);
        void Update(City entity);
        void Delete(City entity);
    }
}
