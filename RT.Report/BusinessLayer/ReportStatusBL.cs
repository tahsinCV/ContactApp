using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RT.Reports.DataLayer;
using RT.Reports.Domain.Interfaces;
using RT.Reports.Domain.Models;
using RT.Reports.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RT.Reports.BusinessLayer
{
    public class ReportStatusBL : IReportStatusBL
    {
        private IReportStatus _reportStatusService;
        private IMapper _mapper;

        public ReportStatusBL(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _reportStatusService = serviceProvider.GetRequiredService<IReportStatus>();
        }

        public Result<ReportStatusDO> Add(ReportStatusDO model)
        {
            Result<ReportStatusDO> result;
            ReportStatus entity;
            try
            {
                entity = _mapper.Map<ReportStatusDO, ReportStatus>(model);
                _reportStatusService.Create(entity);
                model.Id = entity.Id;
                result = new Result<ReportStatusDO>(true, ResultTypeEnum.Success, model, "ReportStatusBL.Add Succeed", "ReportStatusBL.Add Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<ReportStatusDO>(false, ResultTypeEnum.Error, model, "ReportStatusBL.Add failed. ex.Message : " + ex.Message, "ReportStatusBL.Add failed. ex.Message : " + ex.Message);
            }
            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result;
            try
            {
                var entity = _reportStatusService.GetByID(id);
                _reportStatusService.Delete(entity);
                result = new Result<bool>(true, ResultTypeEnum.Success, true, "ReportStatusBL.Delete Succeed", "ReportStatusBL.Delete Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<bool>(false, ResultTypeEnum.Error, false, "ReportStatusBL.Delete Error : " + ex.Message, "ReportStatusBL.Delete Error : " + ex.Message);
            }
            return result;
        }

        public Result<List<ReportStatusDO>> GetAll()
        {
            Result<List<ReportStatusDO>> result;
            try
            {
                List<ReportStatus> reportStatusList = _reportStatusService.GetAll().ToList();
                List<ReportStatusDO> mappedList = _mapper.Map<List<ReportStatus>, List<ReportStatusDO>>(reportStatusList);
                result = new Result<List<ReportStatusDO>>(true, ResultTypeEnum.Success, mappedList, "ReportStatusBL.GetAll Success");
            }
            catch (Exception ex)
            {
                result = new Result<List<ReportStatusDO>>(false, ResultTypeEnum.Error, "An error occured when getting ReportStatusBL.GetAll ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<ReportStatusDO> GetByID(int id)
        {
            Result<ReportStatusDO> result;
            try
            {
                ReportStatus reportStatus = _reportStatusService.GetByID(id);
                ReportStatusDO mappedReportStatus = _mapper.Map<ReportStatus, ReportStatusDO>(reportStatus);
                result = new Result<ReportStatusDO>(true, ResultTypeEnum.Success, mappedReportStatus, "ReportStatusBL.GetByID Success");
            }
            catch (Exception ex)
            {
                result = new Result<ReportStatusDO>(false, ResultTypeEnum.Error, "An error occured when getting ReportStatusBL.GetByID ! Ex : ", ex.Message);
            }
            return result;
        }

        public Result<ReportStatusDO> Update(ReportStatusDO model)
        {
            Result<ReportStatusDO> result;
            try
            {
                var updateEntity = _mapper.Map<ReportStatusDO, ReportStatus>(model);
                _reportStatusService.Update(updateEntity);
                result = new Result<ReportStatusDO>(ResultTypeEnum.Success, model, "ReportStatusBL.Update Succeed", "ReportStatusBL.Update Succeed");
            }
            catch (Exception ex)
            {
                result = new Result<ReportStatusDO>(false, ResultTypeEnum.Error, "An error occured during the updating ReportStatus operation! Ex : " + ex.Message);
            }
            return result;
        }
    }
}
