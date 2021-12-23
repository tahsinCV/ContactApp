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

        public Result<UserInformationDO> Delete(UserInformationDO model)
        {
            Result<UserInformationDO> result;
            try
            {
                var entity = _mapper.Map<UserInformationDO, UserInformation>(model);
                _userInformationService.Delete(entity);
                result = new Result<UserInformationDO>(true, ResultTypeEnum.Success, model, "UserInformationBL.Delete Succeed", "UserInformationBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<UserInformationDO>(false, ResultTypeEnum.Error, model, "UserInformationBL.Delete Error : " + ex.Message, "UserInformationBL.Delete Error : " + ex.Message);
            }
            return result;
        }

        public Result<List<UserInformationDO>> GetAll()
        {
            Result<List<UserInformationDO>> result;
            try
            {
                List<UserInformation> UserInformationList = _userInformationService.GetAll().ToList();
                List<UserInformationDO> mappedList = _mapper.Map<List<UserInformation>, List<UserInformationDO>>(UserInformationList);
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
                UserInformation UserInformation = _userInformationService.GetByID(id);
                UserInformationDO mapperUserInformation = _mapper.Map<UserInformation, UserInformationDO>(UserInformation);
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
