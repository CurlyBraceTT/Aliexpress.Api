using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Exceptions
{
    public class AliApiException : Exception
    {
        public int Code { get; set; }

        public AliApiException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
