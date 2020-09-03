using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.OrderDto
{
    public class CardDto
    {
        public string cardType { get; set; }
        public string cardNumber { get; set; }
        public string expDate { get; set; }
        public int cvnNumber { get; set; }
    }
}
