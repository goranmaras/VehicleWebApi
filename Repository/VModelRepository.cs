using AutoMapper;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos.VModelDto;
using Model.Models;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VModelRepository : IVModelRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VModelRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetVModelDto> GetSingleVehicleModel(int makeId, int id)
        {
            VehicleMake vehicleMakeDb = await _context.VehicleMakes.Include(v => v.VehicleModels).FirstOrDefaultAsync(v => v.Id == makeId);
            VehicleModel vehicleModelDb = vehicleMakeDb.VehicleModels.FirstOrDefault(v => v.Id == id);
            return _mapper.Map<GetVModelDto>(vehicleModelDb);
        }
    }
}
