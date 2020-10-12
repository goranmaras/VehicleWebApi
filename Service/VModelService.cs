﻿using AutoMapper;
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
        private readonly IVModelRepository _repository;
        private readonly IMapper _mapper;

        public VModelService(IVModelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetVModelDto> GetSingleVehicleModel(int makeId, int id) {

            GetVModelDto model = new GetVModelDto();
            model = await _repository.GetSingleVehicleModel(makeId, id);

            return model;
        }
    }
}
