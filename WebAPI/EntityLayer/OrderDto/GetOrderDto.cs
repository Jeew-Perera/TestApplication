using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.OrderDto
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        //public int OrderProductId { get; set; }
        //public int CustomerId { get; set; }
        //public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string ShippingAddress { get; set; }
    }
}
