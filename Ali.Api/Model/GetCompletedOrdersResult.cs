using System.Collections.Generic;

namespace Aliexpress.Api.Model
{
    /// <summary>
    /// GetCompletedOrders Result
    /// </summary>
    public class GetCompletedOrdersResult
    {
        public int TotalResults { get; set; }
        public List<OrderResult> Orders { get; set; }
    }
}
