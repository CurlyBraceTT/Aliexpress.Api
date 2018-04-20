using System.Collections.Generic;

namespace Aliexpress.Api.Model
{
    /// <summary>
    /// ListPromotionProduct Result
    /// </summary>
    public class ListPromotionProductResult
    {
        public int TotalResults { get; set; }
        public List<ProductResult> Products { get; set;} 
    }
}
