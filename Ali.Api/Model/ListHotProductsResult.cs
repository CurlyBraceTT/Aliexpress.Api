using System.Collections.Generic;

namespace Aliexpress.Api.Model
{
    /// <summary>
    /// ListHotProducts Result
    /// </summary>
    public class ListHotProductsResult
    {
        public int TotalResults { get; set; }
        public List<ShortProductResult> Products { get; set; }
    }
}
