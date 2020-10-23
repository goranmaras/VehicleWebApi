using AutoMapper;
using Common.Parameters;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Helpers;
using Model.Parameters;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
//Add this using For Problem in ApplySort Method-----!!!!!!
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<List<GetVMakeDto>> FindAllVMakes(VMakeParameters vMakesParameters)
        {
            //List<T> dbVMakes = await _context.Set<T>().Skip((vMakesParameters.PageNumber - 1) * vMakesParameters.PageSize).
            //    Take(vMakesParameters.PageSize).ToListAsync();
            //return dbVMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();

            //-----Before and after adding the PagedList<T> !!!!------
            var vMakes = await _context.VehicleMakes.ToListAsync();
            vMakes.Find(v => v.Abrv.Length > vMakesParameters.AbrvSize);

            var queryable = vMakes.AsQueryable();
            ApplySort(ref queryable, vMakesParameters.OrderBy);

            var sortedList = queryable.ToList();

            var paged = PagedList<VehicleMake>.ToPagedList(sortedList, vMakesParameters.PageNumber, vMakesParameters.PageSize);

            return _mapper.Map<List<GetVMakeDto>>(paged);
        }

        private void ApplySort(ref IQueryable<VehicleMake> vMakes, string orderByQueryString)
        {
            if (!vMakes.Any())
                return;

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                vMakes = vMakes.OrderBy(x => x.Name);
                return;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(VehicleMake).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                vMakes = vMakes.OrderBy(x => x.Name);
                return;
            }
            //NEEDS System.Linq.Dynamic.Core NugetPackage !!!!------
            vMakes = vMakes.OrderBy(orderQuery);
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
