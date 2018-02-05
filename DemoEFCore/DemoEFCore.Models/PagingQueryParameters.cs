using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.Models
{
    public class PagingQueryParameters
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string QueryExpressionStr { get; set; }
        public string SortExpression { get; set; }
        public bool IsDesc { get; set; }
        public int TotalCount { get; set; }
        public object Data { get; set; }
    }
}
