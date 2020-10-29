using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Parameters
{

    public interface IFilterParameters
    {
        string FilterString { get; set; }
        string CurrentFIlter { get; set; }
    }
    public class FilterParameters : IFilterParameters
    {
        public string FilterString { get; set; }
        public string CurrentFIlter { get; set; }
    }
}
