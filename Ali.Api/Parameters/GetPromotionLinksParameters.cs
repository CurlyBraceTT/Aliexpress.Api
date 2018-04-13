namespace Ali.Api.Parameters
{
    public struct GetPromotionLinksParameters
    {
        public const string DefaultFields = "trackingId,publisherId,promotionUrl";

        public string Fields { get; set; }
        public string TrackingId { get; set; }
        public string Urls { get; set; }

        public GetPromotionLinksParameters(string fields = DefaultFields) : this()
        {
            Fields = fields;
        }
    }
}
