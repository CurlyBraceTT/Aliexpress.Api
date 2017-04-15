using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api.Model
{
    public class OrderResult
    {
        public DateTime OrderTime { get; set; }
        public DateTime TransactionTime { get; set; }
        public long OrderNumber { get; set; }
        public string Product { get; set; }
        public string OrderStatus { get; set; }
        public string CommisionRate { get; set; }
        public string PaymentAmount { get; set; }
        public string EstimatedCommission { get; set; }
        public string FinalPaymentAmount { get; set; }
        public string Commission { get; set; }
        public string PID { get; set; }
        public string ExtraParams { get; set; }
    }
}
