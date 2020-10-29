using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Parameters
{
    public interface IPageParameters
    {
        int? PageSize { get; set; }
        int PageNumber { get; set; }
    }
    public class PageParameters : IPageParameters
    {
        public int? PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
