﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Parameters;
using Repository.Common;
using Service;
using Service.Common;
using VehiclesApi.RestModels;
using System.Net.Http.Formatting;

namespace VehiclesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVMakeService _makeService;
        private readonly IMapper _mapper;

        public VehicleController(IVMakeService makeService, IMapper mapper)
        {
           _makeService = makeService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> FindAllVMakes([FromQuery] Parameters vMakesParameters)
        {
            List<MakeRestResponse> responses = _mapper.Map<List<MakeRestResponse>>(await _makeService.FindAllVMakes(vMakesParameters));
            
          
            if (responses == null)
            {
                return NotFound(responses);
            }


            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleVMake(int id)
        {
           
            MakeRestResponse response = _mapper.Map<MakeRestResponse>(await _makeService.GetVMakeById(id));

            if (response == null)
            {
                
                return NotFound(response);
            }
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSingleVMake(AddVMakeDto newVMake)
        {
            GetVMakeDto vMake = await _makeService.AddVMake(newVMake);
            MakeRestResponse response = _mapper.Map<MakeRestResponse>(vMake);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            
            GetVMakeDto vMake = await _makeService.UpdateVMake(updatedVMake);
            MakeRestResponse response = _mapper.Map<MakeRestResponse>(vMake);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVMake(int id)
        {
           
            MakeRestResponse response = _mapper.Map<MakeRestResponse>(await _makeService.DeleteVMake(id));

            if(response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        

    }
}
