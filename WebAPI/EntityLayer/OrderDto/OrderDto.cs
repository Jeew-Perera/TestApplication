
using EntityLayer.CustomerDto;
using System;
using System.Collections.Generic;

namespace EntityLayer.OrderDto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public CustomerProfileDto BillingDetails { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverPhone { get; set; }
        public List<OrderProductDto> OrderedProducts { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderTotal { get; set; }
        //public CardDto cardDetails { get; set; }
        //public PaymentDto cardDetails { get; set; }
    }
}
