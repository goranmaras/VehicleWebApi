using AutoMapper;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using Model.Parameters;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VMakeRepository : IVMakeRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VMakeRepository(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetVMakeDto>> AddVMake(AddVMakeDto newVMake)
        {
            VehicleMake vehicleMake = _mapper.Map<VehicleMake>(newVMake);
            await _context.VehicleMakes.AddAsync(vehicleMake);
            await _context.SaveChangesAsync();
            return _context.VehicleMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();
        }

        public async Task<List<GetVMakeDto>> DeleteVMake(int id)
        {
            VehicleMake vehicleMake = await _context.VehicleMakes.FirstAsync(v => v.Id == id);
            _context.VehicleMakes.Remove(vehicleMake);
            await _context.SaveChangesAsync();

            return _context.VehicleMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();
        }

        public async Task<List<GetVMakeDto>> GetAllVMakes(VMakesParameters vMakesParameters)
        {
            List<VehicleMake> dbVMakes = await _context.VehicleMakes.Skip((vMakesParameters.PageNumber - 1) * vMakesParameters.PageSize).
                Take(vMakesParameters.PageSize).ToListAsync();
            return dbVMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();
        }

        public async Task<List<GetVMakeDto>> GetAllVMakesWithoutParam()
        {
            List<VehicleMake> dbVMakes = await _context.VehicleMakes.ToListAsync();
            return dbVMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();
        }

        public async Task<GetVMakeDto> GetVMakeById(int id)
        {
            VehicleMake vehicleMakeDb = await _context.VehicleMakes.FirstOrDefaultAsync(v => v.Id == id);
            return _mapper.Map<GetVMakeDto>(vehicleMakeDb);
        }

        public async Task<GetVMakeDto> UpdateVMake(UpdateVMakeDto updatedVMake)
        {
            VehicleMake vehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(v => v.Id == updatedVMake.Id);
            vehicleMake.Name = updatedVMake.Name;
            vehicleMake.Abrv = updatedVMake.Abrv;

            _context.VehicleMakes.Update(vehicleMake);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetVMakeDto>(vehicleMake);
        }
    }
}
