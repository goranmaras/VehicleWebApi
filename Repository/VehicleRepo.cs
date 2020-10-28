using AutoMapper;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Models;
using Model.Parameters;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VehicleRepo : IRepo
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VehicleRepo(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
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

        public async Task<List<GetVMakeDto>> FindAllVMakes(Pagination vMakesParameters)
        {
            List<VehicleMake> dbVMakes = await _context.VehicleMakes.Skip((vMakesParameters.PageNumber - 1) * vMakesParameters.PageSize).
                Take(vMakesParameters.PageSize).ToListAsync();

            return dbVMakes.Select(v => _mapper.Map<GetVMakeDto>(v)).ToList();
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
            vehicleMake.Name = updatedVMake.Name;
            vehicleMake.Abrv = updatedVMake.Abrv;

            _context.VehicleMakes.Update(vehicleMake);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetVMakeDto>(vehicleMake);
        }
    }
}
