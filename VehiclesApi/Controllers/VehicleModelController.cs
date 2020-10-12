using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ModelRestResponse response = _mapper.Map<ModelRestResponse>(await _modelService.GetSingleVehicleModel(makeId, id));

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);


        }
    }
}
