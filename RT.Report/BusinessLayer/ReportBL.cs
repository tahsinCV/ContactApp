using AutoMapper;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RT.Reports.DataLayer;
using RT.Reports.Domain;
using RT.Reports.Domain.Enums;
using RT.Reports.Domain.Interfaces;
using RT.Reports.Domain.Models;
using RT.Reports.Helpers;
using RT.Reports.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Reports.BusinessLayer
{
    public class ReportBL : IReportBL, IConsumer<ReportRequestDO>
    {
        private IReport _reportService;
        private IMapper _mapper;

        public ReportBL(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _reportService = serviceProvider.GetRequiredService<IReport>();
        }

        public Result<ReportDO> Add(ReportDO model)
        {
            Result<ReportDO> result;
            Report entity;
            try
            {
                entity = _mapper.Map<ReportDO, Report>(model);
                _reportService.Create(entity);
                model.Id = entity.Id;
                result = new Result<ReportDO>(true, ResultTypeEnum.Success, model, "ReportBL.Add Succeed", "ReportBL.Add Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<ReportDO>(false, ResultTypeEnum.Error, model, "ReportBL.Add failed. ex.Message : " + ex.Message, "ReportBL.Add failed. ex.Message : " + ex.Message);
            }
            return result;
        }

        public async Task Consume(ConsumeContext<ReportRequestDO> context)
        {

            try
            {
                Report entity = new Report()
                {
                    CityId = context.Message.CityID,
                    Uuid = context.Message.UserID.ToString(),
                    CreateTime = DateTime.Now,
                    CreateUserId = context.Message.UserID,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = context.Message.UserID,
                    IsActive = true,
                    IsDeleted = false,
                    RequestStatusId = (int)ReportStatusEnum.Preparing,
                    PhoneCountInLocation = 0,
                    RequestTime = DateTime.Now,
                    UsersCountInLocation = 0
                };
                _reportService.Create(entity);

                HttpHelper<Result<bool>> helper = new HttpHelper<Result<bool>>();

                var result = await helper.GetSingleItemRequest("https://localhost:44347/api/User/Report?reportsID=" + entity.Id, System.Threading.CancellationToken.None);

            }
            catch (Exception ex)
            {


            }

        }
        public Result<bool> Delete(int id)
        {
            Result<bool> result;
            try
            {
                var entity = _reportService.GetByID(id);
                _reportService.Delete(entity);
                result = new Result<bool>(true, ResultTypeEnum.Success, true, "ReportBL.Delete Succeed", "ReportBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<bool>(false, ResultTypeEnum.Error, false, "ReportBL.Delete Error : " + ex.Message, "ReportBL.Delete Error : " + ex.Message);
            }
            return result;
        }

        public Result<List<ReportDO>> GetAll()
        {
            Result<List<ReportDO>> result;
            try
            {
                List<Report> reportList = _reportService.GetAll().ToList();
                List<ReportDO> mappedList = _mapper.Map<List<Report>, List<ReportDO>>(reportList);
                result = new Result<List<ReportDO>>(true, ResultTypeEnum.Success, mappedList, "ReportBL.GetAll Success");
            }
            catch (Exception ex)
            {
                result = new Result<List<ReportDO>>(false, ResultTypeEnum.Error, "An error occured when getting ReportBL.GetAll ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<ReportDO> GetByID(int id)
        {
            Result<ReportDO> result;
            try
            {
                Report report = _reportService.GetByID(id);
                ReportDO mappedReport = _mapper.Map<Report, ReportDO>(report);
                result = new Result<ReportDO>(true, ResultTypeEnum.Success, mappedReport, "ReportBL.GetByID Success");
            }
            catch (Exception ex)
            {
                result = new Result<ReportDO>(false, ResultTypeEnum.Error, "An error occured when getting ReportBL.GetByID ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<ReportDO> Update(ReportDO model)
        {
            Result<ReportDO> result;
            try
            {

                var updateEntity = _mapper.Map<ReportDO, Report>(model);
                _reportService.Update(updateEntity);
                result = new Result<ReportDO>(ResultTypeEnum.Success, model, "ReportBL.Update Succeed", "ReportBL.Update Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<ReportDO>(false, ResultTypeEnum.Error, "An error occured during the updating Report operation! Ex : " + ex.Message);
            }
            return result;
        }
    }
}
