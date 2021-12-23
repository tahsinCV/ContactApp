using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.DataLayer;
using RT.Contacts.Domain.Interfaces;
using RT.Contacts.Domain.Models;
using RT.Contacts.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.BusinessLayer
{
    public class UserInformationBL:IUserInformationBL
    {

        private IUserInformation _userInformationService;
        private IMapper _mapper;

        public Result<UserInformationDO> Add(UserInformationDO model)
        {
            Result<UserInformationDO> result;
            UserInformation entity;
            try
            {
                entity = _mapper.Map<UserInformationDO, UserInformation>(model);
                _userInformationService.Create(entity);
                model.Id = entity.Id;
                result = new Result<UserInformationDO>(true, ResultTypeEnum.Success, model, "UserInformationBL.Add Succeed", "UserInformationBL.Add Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<UserInformationDO>(false, ResultTypeEnum.Error, model, "UserInformationBL.Add failed. ex.Message : " + ex.Message, "UserInformationBL.Add failed. ex.Message : " + ex.Message);
            }
            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result;
            try
            {
                var entity = _userInformationService.GetByID(id);
                _userInformationService.Delete(entity);
                result = new Result<bool>(true, ResultTypeEnum.Success, true, "UserInformationBL.Delete Succeed", "UserInformationBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<bool>(false, ResultTypeEnum.Error, false, "UserInformationBL.Delete Error : " + ex.Message, "UserInformationBL.Delete Error : " + ex.Message);
            }
            return result;
        }

        public Result<List<UserInformationDO>> GetAll()
        {
            Result<List<UserInformationDO>> result;
            try
            {
                List<UserInformation> userInformationList = _userInformationService.GetAll().ToList();
                List<UserInformationDO> mappedList = _mapper.Map<List<UserInformation>, List<UserInformationDO>>(userInformationList);
                result = new Result<List<UserInformationDO>>(true, ResultTypeEnum.Success, mappedList, "UserInformationBL.GetAll Success");
            }
            catch (Exception ex)
            {
                result = new Result<List<UserInformationDO>>(false, ResultTypeEnum.Error, "An error occured when getting UserInformationBL.GetAll ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<UserInformationDO> GetByID(int id)
        {
            Result<UserInformationDO> result;
            try
            {
                UserInformation userInformation = _userInformationService.GetByID(id);
                UserInformationDO mapperUserInformation = _mapper.Map<UserInformation, UserInformationDO>(userInformation);
                result = new Result<UserInformationDO>(true, ResultTypeEnum.Success, mapperUserInformation, "UserInformationBL.GetByID Success");
            }
            catch (Exception ex)
            {
                result = new Result<UserInformationDO>(false, ResultTypeEnum.Error, "An error occured when getting UserInformationBL.GetByID ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<UserInformationDO> Update(UserInformationDO model)
        {
            Result<UserInformationDO> result;
            try
            {
                var updateEntity = _mapper.Map<UserInformationDO, UserInformation>(model);
                _userInformationService.Update(updateEntity);
                result = new Result<UserInformationDO>(ResultTypeEnum.Success, model, "UserInformationBL.Update Succeed", "UserInformationBL.Update Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<UserInformationDO>(false, ResultTypeEnum.Error, "An error occured during the updating UserInformation operation! Ex : " + ex.Message);
            }
            return result;
        }
    }
}
