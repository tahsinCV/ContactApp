using Microsoft.EntityFrameworkCore;
using RT.Contact.DataLayer;
using RT.Contact.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Service
{
    public class CityService : ICity
    {
        private readonly RTDataContext _dbContext;

        public CityService(RTDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(City entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(City entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<City> GetAll()
        {
            return _dbContext.Cities.AsQueryable();
        }

        public IQueryable<City> GetAllAsNoTracking()
        {
            return _dbContext.Cities.AsNoTracking().AsQueryable();
        }

        public City GetByID(int id)
        {
            return _dbContext.Cities.FirstOrDefault(w=>w.Id == id);
        }

        public void Update(City entity)
        {
            _dbContext.Cities.Update(entity);
        }
    }
}
