using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class GetCompletedOrdersResult
    {
        public int TotalResults { get; set; }
        public List<OrderResult> Orders { get; set; }
    }
}
