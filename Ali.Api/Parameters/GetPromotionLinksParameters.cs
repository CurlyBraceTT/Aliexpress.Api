namespace Ali.Api.Parameters
{
    /// <summary>
    /// GetPromotionLinks Parameters
    /// </summary>
    public class GetPromotionLinksParameters
    {
        public const string DefaultFields = "trackingId,publisherId,promotionUrl";

        public string Fields { get; set; }
        public string TrackingId { get; set; }
        public string Urls { get; set; }

        public GetPromotionLinksParameters(string fields = DefaultFields)
        {
            Fields = fields;
        }
    }
}
