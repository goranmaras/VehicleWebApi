using Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Parameters
{
    public class VMakeParameters : QueryStringParameters
    {
        public VMakeParameters()
        {
            OrderBy = "name";
        }

        public uint AbrvSize { get; set; }

        public bool ValidAbrvSize => AbrvSize > 2;

        public string Name { get; set; }
    }
}
