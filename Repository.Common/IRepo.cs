using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IRepo
    {
        Task<List<GetVMakeDto>> FindAllVMakes(Parameters vMakesParameters);
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<GetVMakeDto> DeleteVMake(int id);
        Task<GetVModelDto> GetSingleVModel(int makeId, int id);
    }
}
