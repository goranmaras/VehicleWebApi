using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common.Experimenting1
{
    public interface IUnitOfWork: IDisposable
    {
        IVMakeRepository VehicleMakes { get; }

        IVModelRepository VehicleModels { get; }
        int Complete();
    }
}
