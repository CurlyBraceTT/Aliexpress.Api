using System;

namespace Ali.Api.Model
{
    /// <summary>
    /// ShortProduct Result
    /// </summary>
    public class ShortProductResult
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
