using System;

namespace Ali.Api.Exceptions
{
    /// <summary>
    /// Aliexpress Api Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class AliApiException : Exception
    {
        public int Code { get; set; }

        public AliApiException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
