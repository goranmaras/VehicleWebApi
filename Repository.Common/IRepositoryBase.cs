using Common.Parameters;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Helpers;
using Model.Parameters;
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
        Task<List<GetVMakeDto>> FindAllVMakes(VMakeParameters vMakesParameters);
        Task<GetVMakeDto> GetVMakeById(int id);
        Task<GetVMakeDto> AddVMake(T newVMake);
        Task<GetVMakeDto> UpdateVMake(T updatedVMake);
        Task<GetVMakeDto> DeleteVMake(int id);
        Task<GetVModelDto> GetSingleVModel(int makeId, int id);
    }
}
