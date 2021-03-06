using RT.Contacts.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.Domain.Interfaces
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
