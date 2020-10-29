using Common.Parameters;
using Model.Dtos;
using Model.Dtos.VModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IRepositoryBase<T> 
    {
        Task<List<GetVMakeDto>> FindAllVMakes(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake);
        Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake);
        Task<GetVMakeDto> DeleteVMake(int id);
        Task<GetVModelDto> GetSingleVModel(int makeId, int id);
    }
}
