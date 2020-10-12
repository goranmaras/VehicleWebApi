using Model;
using Model.Dtos;
using Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVMakeRepository
    {
        Task<List<GetVMakeDto>> GetAllVMakes(VMakesParameters vMakesParameters);
        Task<List<GetVMakeDto>> GetAllVMakesWithoutParam();
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<List<GetVMakeDto>> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<List<GetVMakeDto>> DeleteVMake(int id);
    }
}
