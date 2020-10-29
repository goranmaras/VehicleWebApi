using Common.Parameters;
using Model;
using Model.Dtos;
using Model.Helpers;
using Model.Parameters;
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
        private readonly IRepositoryWrapper _repositoryWrapper;

        public VMakeService( IRepositoryWrapper repositoryWrapper)
        {
           _repositoryWrapper = repositoryWrapper;
        }

        public async Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake)
        {
            GetVMakeDto vMake = await _repositoryWrapper.VehicleMake.AddVMake(newVMake);
            return vMake;
        }

        public async Task<GetVMakeDto> DeleteVMake(int id)
        {
            
            var vMakeDto = await _repositoryWrapper.VehicleMake.DeleteVMake(id);
            
            return vMakeDto;
        }

        public async Task<List<GetVMakeDto>> FindAllVMakes(VMakeParameters vMakesParameters)
        {

            List<GetVMakeDto> allVMake = await _repositoryWrapper.VehicleMake.FindAllVMakes(vMakesParameters);
            return allVMake;
        }

        public async Task<GetVMakeDto> GetVMakeById(int id)
        {
            
            GetVMakeDto vMakeDto = await _repositoryWrapper.VehicleMake.GetVMakeById(id);
            
            return vMakeDto;
        }

        public async Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            GetVMakeDto vMakeDto = new GetVMakeDto();
            vMakeDto = await _repositoryWrapper.VehicleMake.UpdateVMake(updatedVMake);

            return vMakeDto;
        }
    }
}
