using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Parameters
{
    public class ListPromotionCreativeParameters : ParametersCollection
    {
        public string AppSignature { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }
}
