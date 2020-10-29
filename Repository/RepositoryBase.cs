using AutoMapper;
using Common;
using Common.Parameters;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Models;
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

        public async Task<GetVMakeDto> AddVMake(AddVMakeDto newVMake)
        {
            VehicleMake vehicleMake = _mapper.Map<VehicleMake>(newVMake);
            await _context.VehicleMakes.AddAsync(vehicleMake);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetVMakeDto>(vehicleMake);
        }

        public async Task<GetVMakeDto> DeleteVMake(int id)
        {
            VehicleMake vehicleMake = await _context.VehicleMakes.FirstAsync(v => v.Id == id);
            _context.VehicleMakes.Remove(vehicleMake);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetVMakeDto>(vehicleMake);
        }

        public async Task<List<GetVMakeDto>> FindAllVMakes(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vMakes = _context.VehicleMakes.AsQueryable();

            using (_context)
            {
                try
                {
                    checkIfFilterStringIsNull(filterParameters, pageParameters);

                    vMakes = filterByFilterString(filterParameters);

                    vMakes = sort(sortParameters, vMakes);

                    return _mapper.Map<List<GetVMakeDto>>(await PagingList<VehicleMake>.CreateAsync(vMakes, pageParameters.PageNumber, pageParameters.PageSize ?? 5));
                }
                catch (Exception e)
                {
                    return null;
                }

            }

        }

        private IQueryable<VehicleMake> sort(ISortParameters sortParameters, IQueryable<VehicleMake> vMakes)
        {
            switch (sortParameters.SortOrder)
            {
                case "name_asc":
                    vMakes = vMakes != null ? vMakes.OrderBy(m => m.Name).AsQueryable() : _context.VehicleMakes.OrderBy(m => m.Name).AsQueryable();
                    break;

                case "name_desc":
                    vMakes = vMakes != null ? vMakes.OrderByDescending(m => m.Name).AsQueryable() : _context.VehicleMakes.OrderByDescending(m => m.Name).AsQueryable();
                    break;

                case "abrv_asc":
                    vMakes = vMakes != null ? vMakes.OrderBy(m => m.Abrv).AsQueryable() : _context.VehicleMakes.OrderBy(m => m.Abrv).AsQueryable();
                    break;

                case "abrv_desc":
                    vMakes = vMakes != null ? vMakes.OrderByDescending(m => m.Abrv).AsQueryable() : _context.VehicleMakes.OrderByDescending(m => m.Abrv).AsQueryable();
                    break;

                default:
                    vMakes = vMakes != null ? vMakes.OrderBy(m => m.Name).AsQueryable() : _context.VehicleMakes.OrderByDescending(m => m.Name).AsQueryable();
                    break;
            }

            return vMakes;
        }

        private IQueryable<VehicleMake> filterByFilterString(IFilterParameters filterParameters)
        {
            IQueryable<VehicleMake> vehicleMakes;
            if (!string.IsNullOrEmpty(filterParameters.FilterString))
            {
                vehicleMakes = _context.VehicleMakes.Where(v => v.Name.Contains(filterParameters.FilterString) || v.Abrv.Contains(filterParameters.FilterString)).AsQueryable();
            }
            else
            {
                vehicleMakes = null;
            }

            return vehicleMakes;
        }

        private static void checkIfFilterStringIsNull(IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            if (filterParameters.FilterString != null)
            {
                pageParameters.PageNumber = 1;
            }
            else
            {
                filterParameters.FilterString = filterParameters.CurrentFIlter;
            }
        }

        public async Task<GetVModelDto> GetSingleVModel(int makeId, int id)
        {
            VehicleMake vehicleMakeDb = await _context.VehicleMakes.Include(v => v.VehicleModels).FirstOrDefaultAsync(v => v.Id == makeId);
            VehicleModel vehicleModelDb = vehicleMakeDb.VehicleModels.FirstOrDefault(v => v.Id == id);
            return _mapper.Map<GetVModelDto>(vehicleModelDb);
        }

        public async Task<GetVMakeDto> GetVMakeById(int id)
        {
            VehicleMake vehicleMakeDb = await _context.VehicleMakes.FirstOrDefaultAsync(v => v.Id == id);

            return _mapper.Map<GetVMakeDto>(vehicleMakeDb);
        }

        public async Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake)
        {

            VehicleMake vehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(v => v.Id == updatedVMake.Id);

            if (vehicleMake==null)
            {
               return _mapper.Map<GetVMakeDto>(vehicleMake);
            }
            else
            {
                vehicleMake.Name = updatedVMake.Name;
                vehicleMake.Abrv = updatedVMake.Abrv;

                _context.VehicleMakes.Update(vehicleMake);
                await _context.SaveChangesAsync();

                return _mapper.Map<GetVMakeDto>(vehicleMake);
            }

           
        }
    }
}
