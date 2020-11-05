using Common.Parameters;
using Model;
using Model.Dtos;
using Repository.Common;
using Repository.Common.Experimenting1;
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
        private readonly IUnitOfWork _iUnitOfWork;

        public VMakeService(IUnitOfWork iUnitOfWork)
        {
           _iUnitOfWork = iUnitOfWork;
        }

        public async Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake)
        {
            GetVMakeDto vMake = await _iUnitOfWork.VehicleMakes.AddVMake(newVMake);

            return vMake;
        }

        public async Task<GetVMakeDto> DeleteVMake(int id)
        {
            var vMakeDto = await _iUnitOfWork.VehicleMakes.DeleteVMake(id);

            return vMakeDto;
        }

        public async Task<List<GetVMakeDto>> FindAllVMakes(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            List<GetVMakeDto> allVMake = await _iUnitOfWork.VehicleMakes.FindAllVMakes(sortParameters, filterParameters, pageParameters);
            return allVMake;
        }

        public async Task<GetVMakeDto> GetVMakeById(int id)
        {
            GetVMakeDto vMakeDto = await _iUnitOfWork.VehicleMakes.GetVMakeById(id);

            return vMakeDto;
        }

        public async Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            var vMakeDto = await _iUnitOfWork.VehicleMakes.UpdateVMake(updatedVMake);

            return vMakeDto;
        }
    }
}
