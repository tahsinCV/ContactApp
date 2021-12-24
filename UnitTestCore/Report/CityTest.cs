using Moq;
using RT.Reports.Domain.Interfaces;
using RT.Reports.Domain.Models;
using RT.Reports.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestCore.Report
{
    public class CityTest
    {


        #region CityTests

        [Fact]
        public void AddCity()
        {
            var _cityBL = new Mock<ICityBL>();
            CityDO city = new CityDO()
            {
                Name = "test",
                ExternalSystemCode = "test",
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                IsActive = true,
                IsDeleted = false
            };

            Result<CityDO> result = new Result<CityDO>();
            _cityBL.Setup(x => x.Add(city)).Returns(result);
        }

        [Fact]
        public void UpdateCity()
        {
            var _cityBL = new Mock<ICityBL>();
            CityDO city = new CityDO()
            {
                Id = 1,
                Name = "test",
                ExternalSystemCode = "test",
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                IsActive = true,
                IsDeleted = false
            };

            Result<CityDO> result = new Result<CityDO>();
            _cityBL.Setup(x => x.Update(city)).Returns(result);
        }

        [Fact]
        public void DeleteCity()
        {
            var _cityBL = new Mock<ICityBL>();
            Result<bool> result = new Result<bool>();
            _cityBL.Setup(x => x.Delete(1)).Returns(result);
        }

        [Fact]
        public void GetCity()
        {
            var _cityBL = new Mock<ICityBL>();
            Result<CityDO> result = new Result<CityDO>();
            _cityBL.Setup(x => x.GetByID(1)).Returns(result);
        }

        [Fact]
        public void GetCityList()
        {
            var _cityBL = new Mock<ICityBL>();
            Result<List<CityDO>> result = new Result<List<CityDO>>();
            _cityBL.Setup(x => x.GetAll()).Returns(result);
        }


        #endregion









    }
}
