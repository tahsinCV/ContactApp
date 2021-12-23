using AutoMapper;
using RT.Contacts.DataLayer;
using RT.Contacts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.BusinessLayer
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
