using Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Parameters
{
    public class VMakeParameters : Pagination
    {
        public VMakeParameters()
        {
            SortBy = "";
        }

        public string FilterByName { get; set; }

    }
}
