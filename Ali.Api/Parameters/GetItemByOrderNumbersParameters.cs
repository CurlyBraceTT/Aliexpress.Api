﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Parameters
{
    public class GetItemByOrderNumbersParameters : ParametersCollection
    {
        public string AppSignature { get; set; }
        public string OrderNumbers { get; set; }
    }
}
