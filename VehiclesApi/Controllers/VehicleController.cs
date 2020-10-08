using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dtos;
using Repository.Common;
using Service;
using Service.Common;

namespace VehiclesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVMakeService _service;

        public VehicleController(IVMakeService service)
        {
           _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllVMakes()
        {
            return Ok(await _service.GetAllVMakes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleVMake(int id)
        {
            ServiceResponse<GetVMakeDto> response = await _service.GetVMakeById(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSingleVMake(AddVMakeDto newVMake)
        {
            return Ok(await _service.AddVMake(newVMake));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            ServiceResponse<GetVMakeDto> response = await _service.UpdateVMake(updatedVMake);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVMake(int id)
        {
            ServiceResponse<List<GetVMakeDto>> response = await _service.DeleteVMake(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
