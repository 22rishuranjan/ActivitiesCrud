using Application.DTO;
using AutoMapper;

using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapper
{
   public  class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, GetActivityDto>();
            CreateMap<AddActivityDto, Activity>();
            CreateMap<UpdateActivityDto, Activity>();
        }
    }
}
