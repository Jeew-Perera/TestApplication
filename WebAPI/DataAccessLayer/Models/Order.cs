using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
