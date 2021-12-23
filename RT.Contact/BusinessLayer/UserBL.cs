using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.DataLayer;
using RT.Contacts.Domain.Enums;
using RT.Contacts.Domain.Interfaces;
using RT.Contacts.Domain.Models;
using RT.Contacts.Helpers;
using RT.Contacts.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.BusinessLayer
{
    public class UserBL : IUserBL
    {
        private IUser _userService;
        private IMapper _mapper;
        private IUserInformationBL _userInformationBL;

        public UserBL(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _userService = serviceProvider.GetRequiredService<IUser>();
            _userInformationBL = serviceProvider.GetRequiredService<IUserInformationBL>();
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

        public Result<bool> Delete(int id)
        {
            Result<bool> result;
            try
            {
                var entity = _userService.GetByID(id);
                _userService.Delete(entity);
                result = new Result<bool>(true, ResultTypeEnum.Success, true, "UserBL.Delete Succeed", "UserBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<bool>(false, ResultTypeEnum.Error, false, "UserBL.Delete Error : " + ex.Message, "UserBL.Delete Error : " + ex.Message);
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

        public async Task<Result<bool>> SaveReportsDataAsync(int reportsID)
        {
            Result<bool> result = new Result<bool>();
            try
            {
                HttpHelper<Result<ReportDO>> helper = new HttpHelper<Result<ReportDO>>();

                Result<ReportDO> response = await helper.GetSingleItemRequest("https://localhost:44348/api/Report/" + reportsID, System.Threading.CancellationToken.None);

                var userInformationResponse = _userInformationBL.GetAll();
                if (userInformationResponse.IsSuccess)
                {
                    ReportDataResponseDO data = new ReportDataResponseDO()
                    {
                        UserInformationList = userInformationResponse.Data.Where(w => w.CityId == response.Data.CityId).ToList()
                    };
                    response.Data.RequestStatusId = (int)ReportStatusEnum.Prepared;
                    response.Data.PhoneCountInLocation = data.UserInformationList.Where(w => !string.IsNullOrWhiteSpace(w.PhoneNumber)).Count();
                    response.Data.UsersCountInLocation = data.UserInformationList.GroupBy(g => g.CityId).Count();
                    response.Data.UpdateTime = DateTime.Now;


                    HttpHelper<ReportDO> helperUpdate = new HttpHelper<ReportDO>();
                    await helperUpdate.PutRequest("https://localhost:44348/api/Report/"+response.Data.Id, response.Data, System.Threading.CancellationToken.None);

                    result = new Result<bool>(true, ResultTypeEnum.Success, true, "UserBL.SaveReportsData Success");
                }


            }
            catch (Exception ex)
            {
                result = new Result<bool>(false, ResultTypeEnum.Error, "An error occured when getting UserBL.SaveReportsData ! Ex : ", ex.Message);
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
