using AutoMapper;
using RT.Reports.DataLayer;
using RT.Reports.Domain.Models;

namespace RT.Reports.BusinessLayer
{
    public class MapperBL : Profile
    {
        public MapperBL()
        {
            CreateMap<ReportDO, DataLayer.Report>().ReverseMap();
            CreateMap<CityDO, City>().ReverseMap();
            CreateMap<ReportStatusDO, ReportStatus>().ReverseMap();

        }


    }
}
