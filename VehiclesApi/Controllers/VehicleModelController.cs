using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Service;
using Service.Common;
using VehiclesApi.RestModels;

namespace VehiclesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVModelService _modelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVModelService modelService, IMapper mapper)
        {
            _modelService = modelService;
           _mapper = mapper;
        }

        [HttpGet("{makeId}/{id}")]
        public async Task<IActionResult> GetSingleModel(int makeId, int id)
        {
            ModelRestResponse response = _mapper.Map<ModelRestResponse>(await _modelService.GetSingleVModel(makeId, id));

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AddSingleVMake(AddVModelDto newVModel)
        {
            GetVModelDto vModel = await _modelService.AddVModel(newVModel);
            MakeRestResponse response = _mapper.Map<MakeRestResponse>(newVModel);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{makeId}/{id}")]
        public async Task<IActionResult> DeleteVModel(int makeId, int id)
        {

            MakeRestResponse response = _mapper.Map<MakeRestResponse>(await _modelService.DeleteVModel(makeId,id));

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVModel(UpdateVModelDto updateVModel)
        {

            GetVModelDto vModel = await _modelService.UpdateVModel(updateVModel);
            MakeRestResponse response = _mapper.Map<MakeRestResponse>(vModel);

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
