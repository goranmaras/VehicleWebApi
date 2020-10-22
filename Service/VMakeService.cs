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
        private readonly IRepo repository;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public VMakeService(IRepo repository, IRepositoryWrapper repositoryWrapper)
        {
            this.repository = repository;
           _repositoryWrapper = repositoryWrapper;
        }
        public async Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake)
        {
            GetVMakeDto vMake = await repository.AddVMake(newVMake);
            return vMake;
        }

        public async Task<GetVMakeDto> DeleteVMake(int id)
        {
            GetVMakeDto listOfVMake = new GetVMakeDto();
            listOfVMake = await repository.DeleteVMake(id);
            
            return listOfVMake;
        }

        public async Task<List<GetVMakeDto>> FindAllVMakes(Parameters vMakesParameters)
        {
            
            //List<GetVMakeDto> allVMake = await repository.FindAllVMakes(vMakesParameters);
            //return allVMake;

            List<GetVMakeDto> allVMake = await _repositoryWrapper.VehicleMake.FindAllVMakes(vMakesParameters);
            return allVMake;
        }

        public async Task<GetVMakeDto> GetVMakeById(int id)
        {
            
            GetVMakeDto vMakeDto = await repository.GetVMakeById(id);
            
            return vMakeDto;
        }

        public async Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            GetVMakeDto vMakeDto = new GetVMakeDto();
            vMakeDto = await repository.UpdateVMake(updatedVMake);

            return vMakeDto;
        }
    }
}
