using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class ListSimilarProductsResult
    {
        public int TotalResults { get; set; }
        public List<SilimarProductResult> Products { get; set; }

        public class SilimarProductResult
        {
            public long ProductId { get; set; }
            public string ProductTitle { get; set; }

            public string ProductUrl { get; set; }
            public string ImageUrl { get; set; }

            public string SalePrice { get; set; }
            public string LocalPrice { get; set; }

            public int? Volume { get; set; }
            public DateTime ValidTime { get; set; }
        }
    }
}
