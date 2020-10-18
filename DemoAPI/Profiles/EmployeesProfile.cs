using AutoMapper;
using DemoAPI.Dtos;
using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            //Source -> Target
            CreateMap<Employee, EmployeeReadDto>();

            // Target -> Source
            CreateMap<EmployeeCreateDto, Employee>();
        }
    }
}
