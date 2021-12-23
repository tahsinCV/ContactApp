using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RT.Contact.DataLayer;
using RT.Contact.Domain.Interfaces;
using RT.Contact.Domain.Models;
using RT.Contact.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.BusinessLayer
{
    public class UserBL:IUserBL
    {
        private IUser _userService;
        private IMapper _mapper;

        public UserBL(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _userService = serviceProvider.GetRequiredService<IUser>();
        }

        public Result<UserDO> Add(UserDO model)
        {
            Result<UserDO> result;
            User entity;
            try
            {
                entity = _mapper.Map<UserDO, User>(model);
                _userService.Create(entity);
                model.Id = entity.Id;
                result = new Result<UserDO>(true, ResultTypeEnum.Success, model, "UserBL.Add Succeed", "UserBL.Add Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<UserDO>(false, ResultTypeEnum.Error, model, "UserBL.Add failed. ex.Message : " + ex.Message, "UserBL.Add failed. ex.Message : " + ex.Message);
            }
            return result;
        }

        public Result<UserDO> Delete(UserDO model)
        {
            Result<UserDO> result;
            try
            {
                var entity = _mapper.Map<UserDO, User>(model);
                _userService.Delete(entity);
                result = new Result<UserDO>(true, ResultTypeEnum.Success, model, "UserBL.Delete Succeed", "UserBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<UserDO>(false, ResultTypeEnum.Error, model, "UserBL.Delete Error : " + ex.Message, "UserBL.Delete Error : " + ex.Message);
            }
            return result;
        }

        public Result<List<UserDO>> GetAll()
        {
            Result<List<UserDO>> result;
            try
            {
                List<User> userList = _userService.GetAll().ToList();
                List<UserDO> mappedList = _mapper.Map<List<User>, List<UserDO>>(userList);
                result = new Result<List<UserDO>>(true, ResultTypeEnum.Success, mappedList, "UserBL.GetAll Success");
            }
            catch (Exception ex)
            {
                result = new Result<List<UserDO>>(false, ResultTypeEnum.Error, "An error occured when getting UserBL.GetAll ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<UserDO> GetByID(int id)
        {
            Result<UserDO> result;
            try
            {
                User user = _userService.GetByID(id);
                UserDO mapperUser = _mapper.Map<User, UserDO>(user);
                result = new Result<UserDO>(true, ResultTypeEnum.Success, mapperUser, "UserBL.GetByID Success");
            }
            catch (Exception ex)
            {
                result = new Result<UserDO>(false, ResultTypeEnum.Error, "An error occured when getting UserBL.GetByID ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<UserDO> Update(UserDO model)
        {
            Result<UserDO> result;
            try
            {
                var updateEntity = _mapper.Map<UserDO, User>(model);
                _userService.Update(updateEntity);
                result = new Result<UserDO>(ResultTypeEnum.Success, model, "UserBL.Update Succeed", "UserBL.Update Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<UserDO>(false, ResultTypeEnum.Error, "An error occured during the updating User operation! Ex : " + ex.Message);
            }
            return result;
        }
    }
}
