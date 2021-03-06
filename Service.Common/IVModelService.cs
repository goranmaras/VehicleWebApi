﻿using Model.Dtos;
using Model.Dtos.VModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVModelService
    {
        Task<GetVModelDto> GetSingleVModel(int makeId, int id);

        Task<GetVModelDto> AddVModel(AddVModelDto addVModelDto);

        Task<GetVModelDto> UpdateVModel(UpdateVModelDto updateVModelDto);

        Task<GetVModelDto> DeleteVModel(int makeId, int id);
    }
}
