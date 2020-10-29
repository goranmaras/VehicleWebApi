using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Parameters
{
    public interface ISortParameters
    {
        string SortOrder { get; set; }
    }
    public class SortParameters : ISortParameters
    {
        public string SortOrder { get; set; }
    }
}
