using AutoMapper;
using DataAccessLayer.UnitOfWork;
using EntityLayer.ProductDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public ProductManager(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public async Task<IEnumerable<ProductListViewDto>> GetAllProductDetails()
        {
            return await _iUnitOfWork.ProductRepository.GetAllProductDetails();
        }

        public async Task<ProductDetailViewDto> GetProductDetailsById(int productId)
        {
            return await _iUnitOfWork.ProductRepository.GetProductDetailsById(productId);
        }

        public async Task<IEnumerable<ProductListViewDto>> GetProductsByCategory(int categoryId)
        {
            return await _iUnitOfWork.ProductRepository.GetProductsByCategory(categoryId);
        }
    }
}
