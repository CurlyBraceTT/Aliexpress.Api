namespace Ali.Api.Parameters
{
    public struct ListPromotionCreativeParameters
    {
        public string AppSignature { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }
}
