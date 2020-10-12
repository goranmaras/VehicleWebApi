using Model.Dtos;
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
        Task<GetVModelDto> GetSingleVehicleModel(int makeId, int id);
    }
}
