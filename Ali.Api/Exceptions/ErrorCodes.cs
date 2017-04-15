using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Exceptions
{
    public class ErrorCodes
    {
        public const int SucceedCode = 20010000;
        public static Dictionary<int, string> Messages;

        public static string GetMessage(int code)
        {
            if (Messages.ContainsKey(code))
            {
                return Messages[code];
            }

            return "Unexpected error";
        }

        static ErrorCodes()
        {
            Messages = new Dictionary<int, string>()
            {
                { 20020000, "System Error" },
                { 20030000, "Unauthorized transfer request" },
                { 20030010, "Required parameters" },
                { 20030020, "Invalid protocol format" },
                { 20030030, "API version input parameter error" },
                { 20030040, "API name space input parameter error" },
                { 20030050, "API name input parameter error" },
                { 20030060, "Fields input parameter error" },
                { 20030070, "Keyword input parameter error" },
                { 20030080, "Category ID input parameter error" },
                { 20030090, "Tracking ID input parameter error" },
                { 20030100, "Commission rate input parameter error" },
                { 20030110, "Original Price input parameter error" },
                { 20030120, "Discount input parameter error" },
                { 20030130, "Volume input parameter error" },
                { 20030140, "Page number input parameter error" },
                { 20030150, "Page size input parameter error" },
                { 20030160, "Sort input parameter error" },
                { 20030170, "Credit Score input parameter error" }
            };
        }
    }
}
