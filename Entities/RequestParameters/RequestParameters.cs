using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public abstract class RequestParameters
    {
        protected RequestParameters() : this(1,6)
        {
            
        }
        protected RequestParameters(int pageNumber=1, int pageSize=6)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public String? SearchTerm { get; set; }

        public int MinPrice { get; set; } = 0;

        public int MaxPrice { get; set; }=int.MaxValue;

        public bool IsValidPrice => MaxPrice > MinPrice;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
