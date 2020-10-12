using Model;
using Model.Dtos;
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
        private readonly IVMakeRepository repository;

        public VMakeService(IVMakeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetVMakeDto>> AddVMake(AddVMakeDto newVMake)
        {
            await repository.AddVMake(newVMake);
            List<GetVMakeDto> newList = await repository.GetAllVMakesWithoutParam();
            return newList;
        }

        public async Task<List<GetVMakeDto>> DeleteVMake(int id)
        {
            List<GetVMakeDto> listOfVMake = new List<GetVMakeDto>();
            listOfVMake = await repository.DeleteVMake(id);
            
         
            return listOfVMake;
        }

        public async Task<List<GetVMakeDto>> GetAllVMakes(VMakesParameters vMakesParameters)
        {
            List<GetVMakeDto> allVMake = await repository.GetAllVMakes(vMakesParameters);
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
