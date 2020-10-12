using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVMakeService
    {
        Task<List<GetVMakeDto>> GetAllVMakes();
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<List<GetVMakeDto>> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<List<GetVMakeDto>> DeleteVMake(int id);
    }
}
