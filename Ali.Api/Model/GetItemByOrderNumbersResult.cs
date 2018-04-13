using System.Collections.Generic;

namespace Ali.Api.Model
{
    /// <summary>
    /// GetItemByOrderNumbers Result
    /// </summary>
    public class GetItemByOrderNumbersResult
    {
        public int TotalResults { get; set; }
        public List<ShortProductResult> Products { get; set; }
    }
}
