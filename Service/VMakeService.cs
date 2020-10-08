using Model;
using Model.Dtos;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VMakeService : IVMakeService
    {
        private readonly IVMakeRepository repository;

        public VMakeService(IVMakeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ServiceResponse<List<GetVMakeDto>>> AddVMake(AddVMakeDto newVMake)
        {
            ServiceResponse<List<GetVMakeDto>> serviceResponse = new ServiceResponse<List<GetVMakeDto>>();
            await repository.AddVMake(newVMake);
            serviceResponse.Data = await repository.GetAllVMakes();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVMakeDto>>> DeleteVMake(int id)
        {
            ServiceResponse<List<GetVMakeDto>> serviceResponse = new ServiceResponse<List<GetVMakeDto>>();
            try
            {
                serviceResponse.Data = await repository.DeleteVMake(id);
                serviceResponse.Message = "Successfully deleted!";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVMakeDto>>> GetAllVMakes()
        {
            ServiceResponse<List<GetVMakeDto>> serviceResponse = new ServiceResponse<List<GetVMakeDto>>();
            serviceResponse.Data = await repository.GetAllVMakes();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVMakeDto>> GetVMakeById(int id)
        {
            ServiceResponse<GetVMakeDto> serviceResponse = new ServiceResponse<GetVMakeDto>();
            serviceResponse.Data = await repository.GetVMakeById(id);
            
            if(serviceResponse.Data == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No instance with that ID";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVMakeDto>> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            ServiceResponse<GetVMakeDto> serviceResponse = new ServiceResponse<GetVMakeDto>();
            try {
                serviceResponse.Data = await repository.UpdateVMake(updatedVMake);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
