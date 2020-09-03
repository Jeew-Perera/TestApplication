using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Payment
    {
        public int PayementId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvn { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
