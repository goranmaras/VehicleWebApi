using Common.Parameters;
using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common.Experimenting1
{
   public interface IVMakeRepository : IGenericRepository<VehicleMake>
    {
        Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> DeleteVMake(int id);
        Task<List<GetVMakeDto>> FindAllVMakes(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
    }
}
