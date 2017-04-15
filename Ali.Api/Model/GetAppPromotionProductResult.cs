using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class GetAppPromotionProductResult
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }

        public string ProductUrl { get; set; }
        public string AppProductUrl { get; set; }

        public string Image220 { get; set; }
        public string Image350 { get; set; }
        public string Image640 { get; set; }
    }
}
