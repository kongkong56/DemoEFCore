using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.Models
{
    public class PaginationInfo
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 0;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
