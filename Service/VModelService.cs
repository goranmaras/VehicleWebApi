using AutoMapper;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Models;
using Repository.Common;
using Repository.Common.Experimenting1;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VModelService : IVModelService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;

        public VModelService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        public async Task<GetVModelDto> AddVModel(AddVModelDto addVModelDto)
        {
            GetVModelDto vModelDto = await _iUnitOfWork.VehicleModels.AddVModel(addVModelDto);

            return vModelDto;
        }

        public async Task<GetVModelDto> DeleteVModel(int makeId, int id)
        {
            var vModelDto = await _iUnitOfWork.VehicleModels.DeleteVModel(makeId, id);

            return vModelDto;
        }

        public async Task<GetVModelDto> GetSingleVModel(int makeId, int id) {

            var model = await _iUnitOfWork.VehicleModels.GetSingleVModel(makeId, id);

            return model;
        }

        public async Task<GetVModelDto> UpdateVModel(UpdateVModelDto updateVModelDto)
        {
            var vModelDto = await _iUnitOfWork.VehicleModels.UpdateVModel(updateVModelDto);

            return vModelDto;
        }
    }
}
