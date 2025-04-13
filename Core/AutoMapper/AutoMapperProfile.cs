using AutoMapper;
using Core.DTOs.Request;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddStudentRequest, Student>();
            CreateMap<AddAccountRequest, Account>();
        }
    }
}
