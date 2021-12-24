using Moq;
using RT.Contacts.Domain.Enums;
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
    public class ReportTest
    {


        #region ReportTests

        [Fact]
        public void AddReport()
        {
            var _reportBL = new Mock<IReportBL>();
            ReportDO report = new ReportDO()
            {
                CityId =1,
                Uuid="1",
                PhoneCountInLocation=0,
                UsersCountInLocation = 0,
                RequestStatusId =(int)ReportStatusEnum.Preparing,
                RequestTime=DateTime.Now,
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                IsActive = true,
                IsDeleted = false
            };

            Result<ReportDO> result = new Result<ReportDO>();
            _reportBL.Setup(x => x.Add(report)).Returns(result);
        }

        [Fact]
        public void UpdateReport()
        {
            ReportDO report = new ReportDO()
            {
                Id=1,
                CityId = 1,
                Uuid = "1",
                PhoneCountInLocation = 0,
                UsersCountInLocation = 0,
                RequestStatusId = (int)ReportStatusEnum.Preparing,
                RequestTime = DateTime.Now,
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                IsActive = true,
                IsDeleted = false
            };

            var _reportBL = new Mock<IReportBL>();
            Result<ReportDO> result = new Result<ReportDO>();
            _reportBL.Setup(x => x.Update(report)).Returns(result);
        }

        [Fact]
        public void DeleteReport()
        {
            var _reportBL = new Mock<IReportBL>();
            Result<bool> result = new Result<bool>();
            _reportBL.Setup(x => x.Delete(1)).Returns(result);
        }

        [Fact]
        public void GetReport()
        {
            var _reportBL = new Mock<IReportBL>();
            Result<ReportDO> result = new Result<ReportDO>();
            _reportBL.Setup(x => x.GetByID(1)).Returns(result);
        }

        [Fact]
        public void GetReportList()
        {
            var _reportBL = new Mock<IReportBL>();
            Result<List<ReportDO>> result = new Result<List<ReportDO>>();
            _reportBL.Setup(x => x.GetAll()).Returns(result);
        }


        #endregion









    }
}
