using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
