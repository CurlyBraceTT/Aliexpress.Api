using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Parameters
{
    public class GetCompletedOrdersParameters : ParametersCollection
    {
        public string AppSignature { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LiveOrderStatus { get; set; }
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }
}
