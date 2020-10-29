using Common.Parameters;
using Model;
using Model.Dtos;
using Model.Helpers;
using Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVMakeService
    {
        Task<List<GetVMakeDto>> FindAllVMakes(SortParameters sortParameters, FilterParameters filterParameters, PageParameters pageParameters);
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<GetVMakeDto> DeleteVMake(int id);

    }
}
