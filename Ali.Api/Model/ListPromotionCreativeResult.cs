﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class ListPromotionCreativeResult
    {
        public int TotalResults { get; set; }
        public List<PromotionCreativeResult> Products { get; set; }

        public class PromotionCreativeResult
        {
            public string ActivityUrl { get; set; }
            public DateTime ActivityTime { get; set; }
            public string ActivityTitle { get; set; }
            public string Description { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
