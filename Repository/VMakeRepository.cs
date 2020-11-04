using AutoMapper;
using Common;
using Common.Parameters;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using Repository.Common;
using Repository.Common.Experimenting1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Experimienting1
{
    public class VMakeRepository : GenericRepository<VehicleMake>, IVMakeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VMakeRepository(DataContext dataContext, IMapper mapper) : base(dataContext)
        {
            _context = dataContext;
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
                    CheckIfFilterStringNull(filterParameters, pageParameters);

                    vMakes = FilterByString(filterParameters);

                    vMakes = SortParameters(sortParameters, vMakes);

                    return _mapper.Map<List<GetVMakeDto>>(await PagingList<VehicleMake>.CreateAsync(vMakes, pageParameters.PageNumber, pageParameters.PageSize ?? 5));
                }
                catch (Exception e)
                {
                    return null;
                }

            }
        }

        public async Task<GetVMakeDto> GetVMakeById(int id)
        {
            VehicleMake vehicleMakeDb = await _context.VehicleMakes.FirstOrDefaultAsync(v => v.Id == id);

            return _mapper.Map<GetVMakeDto>(vehicleMakeDb);
        }

        public async Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            VehicleMake vehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(v => v.Id == updatedVMake.Id);

            if (vehicleMake == null)
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

        #region VMakeRepository helper methods
        //Helper methods
        private IQueryable<VehicleMake> SortParameters(ISortParameters sortParameters, IQueryable<VehicleMake> vMakes)
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

        private IQueryable<VehicleMake> FilterByString(IFilterParameters filterParameters)
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

        private static void CheckIfFilterStringNull(IFilterParameters filterParameters, IPageParameters pageParameters)
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
        #endregion

    }
}
