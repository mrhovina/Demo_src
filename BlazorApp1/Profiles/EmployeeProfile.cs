using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //Source -> Target
            CreateMap<Models.EmployeeViewModel, CommonSRC.Dtos.EmployeeCreateDto>();
            CreateMap<Models.EmployeeViewModel, CommonSRC.Dtos.EmployeeUpdateDto>();
            // Target -> Source
            CreateMap<CommonSRC.Dtos.EmployeeReadDto, Models.EmployeeViewModel > ();
        }
    }
}
