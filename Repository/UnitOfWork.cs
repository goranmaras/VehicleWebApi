using AutoMapper;
using DAL.Data;
using Repository.Common.Experimenting1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Experimienting1
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
           _mapper = mapper;

            VehicleMakes = new VMakeRepository(_context, _mapper);

            VehicleModels = new VModelRepository(_context, _mapper);
        }
        public IVMakeRepository VehicleMakes { get; private set; }

        public IVModelRepository VehicleModels { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
