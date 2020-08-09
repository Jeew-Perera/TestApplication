using EntityLayer.ProductDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductManager
    {
        Task<IEnumerable<ProductListViewDto>> GetAllProductDetails();
        Task<ProductDetailViewDto> GetProductDetailsById(int id);
        Task<IEnumerable<ProductListViewDto>> GetProductsByCategory(int categoryId);
    }
}
