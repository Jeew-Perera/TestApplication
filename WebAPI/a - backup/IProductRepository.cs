using EntityLayer.ProductDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductListViewDto>> GetAllProductDetails();
        Task<ProductDetailViewDto> GetProductDetailsById(int productId);
        Task<IEnumerable<ProductListViewDto>> GetProductsByCategory(int categoryId);
        //Task<IEnumerable<ProductDetailViewDto>> GetProductsByCategory(int categoryId);
    }
}
