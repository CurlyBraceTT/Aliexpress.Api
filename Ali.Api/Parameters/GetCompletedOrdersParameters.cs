using System;

namespace Ali.Api.Parameters
{
    public struct GetCompletedOrdersParameters
    {
        public string AppSignature { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LiveOrderStatus { get; set; }
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }
}
