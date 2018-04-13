using System.Collections.Generic;

namespace Ali.Api.Model
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
