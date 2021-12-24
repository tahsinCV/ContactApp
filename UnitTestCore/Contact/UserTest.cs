using Moq;
using RT.Contacts.Domain.Interfaces;
using RT.Contacts.Domain.Models;
using RT.Contacts.ResultType;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestCore.Contact
{
    public class UserTest
    {


        #region UserTests

        [Fact]
        public void AddUser()
        {
            var _userBL = new Mock<IUserBL>();
            UserDO user = new UserDO()
            {
                Name = "test",
                SurName = "test",
                CompanyName = "test",
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                IsActive = true,
                IsDeleted = false,
                Uuid = Guid.NewGuid().ToString()
            };

            Result<UserDO> result = new Result<UserDO>();
            _userBL.Setup(x => x.Add(user)).Returns(result);
        }

        [Fact]
        public void UpdateUser()
        {
            var _userBL = new Mock<IUserBL>();
            UserDO user = new UserDO()
            {
                Id = 1,
                Name = "test",
                SurName = "test",
                CompanyName = "test",
                CreateTime = DateTime.Now,
                CreateUserId = 1,
                UpdateTime = DateTime.Now,
                UpdateUserId = 1,
                IsActive = true,
                IsDeleted = false,


                Uuid = Guid.NewGuid().ToString()
            };

            Result<UserDO> result = new Result<UserDO>();
            _userBL.Setup(x => x.Update(user)).Returns(result);
        }

        [Fact]
        public void DeleteUser()
        {
            var _userBL = new Mock<IUserBL>();
            Result<bool> result = new Result<bool>();
            _userBL.Setup(x => x.Delete(1)).Returns(result);

        }

        [Fact]
        public void GetUser()
        {
            var _userBL = new Mock<IUserBL>();
            Result<UserDO> result = new Result<UserDO>();
            _userBL.Setup(x => x.GetByID(1)).Returns(result);

        }

        [Fact]
        public void GetAllUser()
        {
            var _userBL = new Mock<IUserBL>();
            Result<List<UserDO>> result = new Result<List<UserDO>>();
            _userBL.Setup(x => x.GetAll()).Returns(result);
        }

        #endregion

    }
}
