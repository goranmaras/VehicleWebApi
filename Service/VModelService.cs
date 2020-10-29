using AutoMapper;
using Model;
using Model.Dtos.VModelDto;
using Model.Models;
using Repository.Common;
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
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public VModelService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<GetVModelDto> GetSingleVehicleModel(int makeId, int id) {

            
            var model = await _repositoryWrapper.VehicleModel.GetSingleVModel(makeId, id);

            return model;
        }
    }
}
