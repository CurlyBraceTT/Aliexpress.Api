using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    /// <summary>
    /// GetPromotionLinks Result
    /// </summary>
    public class GetPromotionLinksResult
    {
        public int TotalResults { get; set; }
        public string TrackingId { get; set; }
        public string PublisherId { get; set; }
        public string Url { get; set; }
        public List<PromotionUrlResult> PromotionUrls { get; set; }
        public string LocalPrice { get; set; }

        public class PromotionUrlResult
        {
            public string Url { get; set; }
            public string PromotionUrl { get; set; }
        }
    }
}
