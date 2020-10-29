using AutoMapper;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesApi.RestModels;

namespace Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMake, GetVMakeDto>();
            CreateMap<GetVMakeDto, MakeRestResponse>();
            CreateMap<AddVMakeDto, VehicleMake>();
            CreateMap<MakeRestResponse, AddVMakeDto>();
            CreateMap<MakeRestResponse, GetVMakeDto>();
            CreateMap<VehicleModel, GetVModelDto>();
            CreateMap<GetVModelDto, ModelRestResponse>().ReverseMap();
        }
    }
}
