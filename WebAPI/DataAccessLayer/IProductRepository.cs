using DataAccessLayer.Models;
using EntityLayer;
using EntityLayer.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductListViewDto>> GetAllProductDetails();
        Task<ProductDetailViewDto> GetProductDetailsById(int productId);
        Task<IEnumerable<ProductListViewDto>> GetProductsByCategory(int categoryId);
    }
}
