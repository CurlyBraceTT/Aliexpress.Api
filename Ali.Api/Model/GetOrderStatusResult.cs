using System.Collections.Generic;

namespace Ali.Api.Model
{
    /// <summary>
    /// GetOrderStatus Result
    /// </summary>
    public class GetOrderStatusResult
    {
        public int TotalResults { get; set; }
        public List<OrderResult> Orders { get; set; }
    }
}
