namespace Ali.Api.Parameters
{
    /// <summary>
    /// ListPromotionProduct Parameters
    /// </summary>
    public class ListPromotionProductParameters
    {
        public const string DefaultFields = "productId,productTitle,productUrl,salePrice,originalPrice,imageUrl,evaluateScore";

        public string Fields { get; set; }
        public string Keywords { get; set; }
        public string CategoryId { get; set; }

        public double? OriginalPriceFrom { get; set; }
        public double? OriginalPriceTo { get; set; }

        public int? VolumeFrom { get; set; }
        public int? VolumeTo { get; set; }

        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
        public string Sort { get; set; }

        public int? StartCreditScore { get; set; }
        public int? EndCreditScore { get; set; }

        public string HighQualityItems { get; set; }
        public string LocalCurrency { get; set; }
        public string Language { get; set; }

        public ListPromotionProductParameters(string fields = DefaultFields)
        {
            Fields = fields;
        }
    }
}
