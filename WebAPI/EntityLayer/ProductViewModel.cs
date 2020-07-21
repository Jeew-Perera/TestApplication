using System;

namespace EntityLayer
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
    }
}
