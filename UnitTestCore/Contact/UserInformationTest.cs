using Moq;
using RT.Contacts.Domain.Interfaces;
using RT.Contacts.Domain.Models;
using RT.Contacts.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestCore.Contact
{
    public class UserInformationTest
    {




        #region UserInformationTests

        [Fact]
        public void AddUserInformation()
        {
            var _userInformationBL = new Mock<IUserInformationBL>();
            UserInformationDO userInformation = new UserInformationDO()
            {
                UserId = 1,
                CityId = 1,
                PhoneNumber = "5555555555",
                Information = "test",
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                Email = "test@gmail.com",
                IsActive = true,
                IsDeleted = true,
            };
            Result<UserInformationDO> result = new Result<UserInformationDO>();
            _userInformationBL.Setup(x => x.Add(userInformation)).Returns(result);

        }

        [Fact]
        public void UpdateUserInformation()
        {
            var _userInformationBL = new Mock<IUserInformationBL>();
            UserInformationDO userInformation = new UserInformationDO()
            {
                Id = 1,
                UserId = 1,
                CityId = 1,
                PhoneNumber = "5555555555",
                Information = "test",
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                Email = "test@gmail.com",
                IsActive = true,
                IsDeleted = true,
            };

            Result<UserInformationDO> result = new Result<UserInformationDO>();
            _userInformationBL.Setup(x => x.Update(userInformation)).Returns(result);
        }

        [Fact]
        public void DeleteUserInformation()
        {
            var _userInformationBL = new Mock<IUserInformationBL>();
            Result<bool> result = new Result<bool>();
            _userInformationBL.Setup(x => x.Delete(1)).Returns(result);
        }

        [Fact]
        public void GetUserInformation()
        {
            var _userInformationBL = new Mock<IUserInformationBL>();
            Result<UserInformationDO> result = new Result<UserInformationDO>();
            _userInformationBL.Setup(x => x.GetByID(1)).Returns(result);
        }

        [Fact]
        public void GetUserInformationList()
        {
            var _userInformationBL = new Mock<IUserInformationBL>();
            Result<List<UserInformationDO>> result = new Result<List<UserInformationDO>>();
            _userInformationBL.Setup(x => x.GetAll()).Returns(result);
        }

        #endregion






    }
}
