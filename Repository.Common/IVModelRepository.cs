using Model.Dtos.VModelDto;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVModelRepository
    {
        Task<GetVModelDto> GetSingleVehicleModel(int makeId, int id);
    }
}
