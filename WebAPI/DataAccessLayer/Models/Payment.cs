using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string CardType { get; set; }

        public virtual Order Order { get; set; }
    }
}
