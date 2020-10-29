using AutoMapper;
using DAL.Data;
using Model.Models;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class VModelRepo : RepositoryBase<VehicleModel>, IVModelRepo
    {

        public VModelRepo(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }

    }
}
