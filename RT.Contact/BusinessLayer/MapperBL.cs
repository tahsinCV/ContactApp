using AutoMapper;
using RT.Contact.DataLayer;
using RT.Contact.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.BusinessLayer
{
    public class MapperBL:Profile
    {
        public MapperBL()
        {
            CreateMap<UserDO, User>().ReverseMap();
            CreateMap<CityDO, City>().ReverseMap();
            CreateMap<UserInformationDO, UserInformation>().ReverseMap();
  
        }
        

    }
}
