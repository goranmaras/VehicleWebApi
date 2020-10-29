using Common.Parameters;
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
        Task<List<GetVMakeDto>> FindAllVMakes(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<GetVMakeDto> DeleteVMake(int id);

    }
}
