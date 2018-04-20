using Newtonsoft.Json;
using System;

namespace Aliexpress.Api.Model
{
    /// <summary>
    /// Product Result
    /// </summary>
    public class ProductResult
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }

        public string ProductUrl { get; set; }
        public string ImageUrl { get; set; }

        public string OriginalPrice { get; set; }
        public string SalePrice { get; set; }
        public string Discount { get; set; }
        public string LocalPrice { get; set; }

        public float EvaluateScore { get; set; }

        public string Commission { get; set; }
        public string CommissionRate { get; set; }
        [JsonProperty("30daysCommission")]
        public string DaysCommission30 { get; set; }

        public int? Volume { get; set; }
        public string PackageType { get; set; }
        public int LotNum { get; set; }
        public DateTime ValidTime { get; set; }
        public string AllImageUrls { get; set; }
    }
}
