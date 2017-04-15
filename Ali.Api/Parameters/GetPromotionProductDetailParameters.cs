using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Parameters
{
    public class GetPromotionProductDetailParameters : ParametersCollection
    {
        public const string DefaultFields = "productId,productTitle,productUrl,salePrice,originalPrice,imageUrl,evaluateScore";

        public string Fields { get; set; }
        public string ProductId { get; set; }
        public string LocalCurrency { get; set; }
        public string Language { get; set; }

        public GetPromotionProductDetailParameters(string fields = DefaultFields)
        {
            Fields = fields;
        }
    }
}
