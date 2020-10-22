using AutoMapper;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Parameters;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        protected RepositoryBase(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<GetVMakeDto> AddVMake(T newVMake)
        {
            throw new NotImplementedException();
        }

        public Task<GetVMakeDto> DeleteVMake(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetVMakeDto>> FindAllVMakes(Parameters vMakesParameters)
        {
            List<T> dbVMakes = await _context.Set<T>().Skip((vMakesParameters.PageNumber - 1) * vMakesParameters.PageSize).
                Take(vMakesParameters.PageSize).ToListAsync();

            return dbVMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();
        }

        public Task<GetVModelDto> GetSingleVModel(int makeId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetVMakeDto> GetVMakeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetVMakeDto> UpdateVMake(T updatedVMake)
        {
            throw new NotImplementedException();
        }
    }
}
