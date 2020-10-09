using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Repository.Common;
using Service;
using Service.Common;

namespace VehiclesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVMakeService _makeService;
        private readonly IVModelService _modelService;
        private readonly IMapper _mapper;

        public VehicleController(IVMakeService makeService, IVModelService modelService, IMapper mapper)
        {
           _makeService = makeService;
           _modelService = modelService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllVMakes()
        {
            return Ok(await _makeService.GetAllVMakes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleVMake(int id)
        {
            ServiceResponse<GetVMakeDto> response = await _makeService.GetVMakeById(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSingleVMake(AddVMakeDto newVMake)
        {
            return Ok(await _makeService.AddVMake(newVMake));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            ServiceResponse<GetVMakeDto> response = await _makeService.UpdateVMake(updatedVMake);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVMake(int id)
        {
            ServiceResponse<List<GetVMakeDto>> response = await _makeService.DeleteVMake(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{makeId}/{id}")]
        public async Task<IActionResult> GetSingleModel(int makeId, int id)
        {
            ServiceResponse<GetVModelDto> response = await _modelService.GetSingleVehicleModel(makeId, id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);


        }

    }
}
