﻿using AutoMapper;
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
    public class CityBL : ICityBL
    {
        private ICity _cityService;
        private IMapper _mapper;

        public CityBL(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _cityService = serviceProvider.GetRequiredService<ICity>();
        }

        public Result<CityDO> Add(CityDO model)
        {
            Result<CityDO> result;
            City entity;
            try
            {
                entity = _mapper.Map<CityDO, City>(model);
                _cityService.Create(entity);
                model.Id = entity.Id;
                result = new Result<CityDO>(true, ResultTypeEnum.Success, model, "CityBL.Add Succeed", "CityBL.Add Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<CityDO>(false, ResultTypeEnum.Error, model, "CityBL.Add failed. ex.Message : " + ex.Message, "CityBL.Add failed. ex.Message : " + ex.Message);
            }
            return result;
        }

        public  Result<bool> Delete(int id)
        {
            Result<bool> result;
            try
            {
                var entity = _cityService.GetByID(id);
                _cityService.Delete(entity);
                result = new Result<bool>(true, ResultTypeEnum.Success, true, "CityBL.Delete Succeed", "CityBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<bool>(false, ResultTypeEnum.Error, false, "CityBL.Delete Error : " + ex.Message, "CityBL.Delete Error : " + ex.Message);
            }
            return result;
        }

        public Result<List<CityDO>> GetAll()
        {
            Result<List<CityDO>> result;
            try
            {
                List<City> CityList = _cityService.GetAll().ToList();
                List<CityDO> mappedList = _mapper.Map<List<City>, List<CityDO>>(CityList);
                result = new Result<List<CityDO>>(true, ResultTypeEnum.Success, mappedList, "CityBL.GetAll Success");
            }
            catch (Exception ex)
            {
                result = new Result<List<CityDO>>(false, ResultTypeEnum.Error, "An error occured when getting CityBL.GetAll ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<CityDO> GetByID(int id)
        {
            Result<CityDO> result;
            try
            {
                City City = _cityService.GetByID(id);
                CityDO mapperCity = _mapper.Map<City, CityDO>(City);
                result = new Result<CityDO>(true, ResultTypeEnum.Success, mapperCity, "CityBL.GetByID Success");
            }
            catch (Exception ex)
            {
                result = new Result<CityDO>(false, ResultTypeEnum.Error, "An error occured when getting CityBL.GetByID ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<CityDO> Update(CityDO model)
        {
            Result<CityDO> result;
            try
            {
                var updateEntity = _mapper.Map<CityDO, City>(model);
                _cityService.Update(updateEntity);
                result = new Result<CityDO>(ResultTypeEnum.Success, model, "CityBL.Update Succeed", "CityBL.Update Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<CityDO>(false, ResultTypeEnum.Error, "An error occured during the updating City operation! Ex : " + ex.Message);
            }
            return result;
        }
    }
}
