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
        Task<ServiceResponse<List<GetVMakeDto>>> GetAllVMakes();
        Task<ServiceResponse<GetVMakeDto>> GetVMakeById(int id);
        Task<ServiceResponse<List<GetVMakeDto>>> AddVMake(AddVMakeDto newVMake);
        Task<ServiceResponse<GetVMakeDto>> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<ServiceResponse<List<GetVMakeDto>>> DeleteVMake(int id);
    }
}
