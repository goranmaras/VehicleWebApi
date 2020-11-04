using AutoMapper;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using Model.Dtos.VModelDto;
using Model.Models;
using Repository.Common.Experimenting1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Experimienting1
{
    public class VModelRepository : GenericRepository<VehicleModel>, IVModelRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VModelRepository(DataContext dataContext, IMapper mapper) : base(dataContext)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        public async Task<GetVModelDto> AddVModel(AddVModelDto addVModelDto)
        {
            VehicleModel vehicleModel = _mapper.Map<VehicleModel>(addVModelDto);
            await _context.VehicleModels.AddAsync(vehicleModel);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetVModelDto>(vehicleModel);
        }

        public async Task<GetVModelDto> DeleteVModel(int makeId, int id)
        {
            var vMake = await _context.VehicleMakes.FirstAsync(v => v.Id == makeId);
            VehicleModel vehicleModelDb = new VehicleModel();

            if (vMake != null)
            {
                vehicleModelDb = await _context.VehicleModels.FirstOrDefaultAsync(v => v.Id == id);

                if(vehicleModelDb != null)
                {
                    _context.VehicleModels.Remove(vehicleModelDb);
                    await _context.SaveChangesAsync();
                }
                
            }
            

            return _mapper.Map<GetVModelDto>(vehicleModelDb);
        }

        public async Task<GetVModelDto> GetSingleVModel(int makeId, int id)
        {
            VehicleMake vehicleMakeDb = await _context.VehicleMakes.Include(v => v.VehicleModels).FirstOrDefaultAsync(v => v.Id == makeId);
            VehicleModel vehicleModelDb = vehicleMakeDb.VehicleModels.FirstOrDefault(v => v.Id == id);
            return _mapper.Map<GetVModelDto>(vehicleModelDb);
        }

        public async Task<GetVModelDto> UpdateVModel(UpdateVModelDto updateVModelDto)
        {
            VehicleModel vehicleModel = await _context.VehicleModels.FirstOrDefaultAsync(v => v.Id == updateVModelDto.Id);

            if (vehicleModel == null)
            {
                return _mapper.Map<GetVModelDto>(vehicleModel);
            }
            else
            {
                vehicleModel.Name = updateVModelDto.Name;
                vehicleModel.Abrv = updateVModelDto.Abrv;

                _context.VehicleModels.Update(vehicleModel);
                await _context.SaveChangesAsync();

                return _mapper.Map<GetVModelDto>(vehicleModel);
            }
        }
    }
}
