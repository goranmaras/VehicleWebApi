using AutoMapper;
using DAL.Data;
using Model;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VMakeRepo : RepositoryBase<VehicleMake>, IVMakeRepo
    {

        public VMakeRepo(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }

        

    }
}
