using AutoMapper;
using DAL.Data;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private IVMakeRepo _vMakeRepo;
        private IVModelRepo _vModelRepo;

        public IVMakeRepo VehicleMake
        {
            get
            {
                if (_vMakeRepo == null)
                {
                    _vMakeRepo = new VMakeRepo(_dataContext, _mapper);
                }

                return _vMakeRepo;
            }
        }

        public IVModelRepo VehicleModel
        {
            get
            {
                if(_vModelRepo == null)
                {
                    _vModelRepo = new VModelRepo(_dataContext, _mapper);
                }

                return _vModelRepo;
            }
        }

        public RepositoryWrapper(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

    }
}
