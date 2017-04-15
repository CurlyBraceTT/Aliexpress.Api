using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Parameters
{
    public class ListHotProductsParameters : ParametersCollection
    {
        public string Language { get; set; }
        public string CategoryId { get; set; }
        public string LocalCurrency { get; set; }
    }
}
