using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class GetItemByOrderNumbersResult
    {
        public int TotalResults { get; set; }
        public List<ShortProductResult> Products { get; set; }
    }
}
