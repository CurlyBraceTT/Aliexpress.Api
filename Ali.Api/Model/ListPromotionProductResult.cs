using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class ListPromotionProductResult
    {
        public int TotalResults { get; set; }
        public List<ProductResult> Products { get; set;} 
    }
}
