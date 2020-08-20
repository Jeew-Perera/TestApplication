using System.Collections.Generic;

namespace EntityLayer.ProductDto
{
    public class CategoryBasedProductListViewDto
    {
        public int CategoryId { get; set; }

        public IEnumerable<ProductDetailViewDto> ProductList { get; set; }

    }
}
