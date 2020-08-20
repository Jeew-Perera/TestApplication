using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer.ProductDto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public ProductRepository(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<IEnumerable<ProductListViewDto>> GetAllProductDetails()
        {
            var products = await _context.Product.ToListAsync();
            return _iMapper.Map<ProductListViewDto[]>(products);
        }

        public async Task<ProductDetailViewDto> GetProductDetailsById(int productId)
        {
            var product = await _context.Product.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            return _iMapper.Map<ProductDetailViewDto>(product);
        }

        public async Task<IEnumerable<ProductListViewDto>> GetProductsByCategory(int categoryId)
        {
            var categoryBasedProducts = await _context.Product.Where(p => p.CategoryId == categoryId).ToListAsync();
            return _iMapper.Map<ProductListViewDto[]>(categoryBasedProducts);
        }

        //public async Task<IEnumerable<ProductDetailViewDto>> GetProductsByCategory(int categoryId)
        //{
        //    var categoryBasedProducts = await _context.Product.Where(p => p.CategoryId == categoryId).ToListAsync();
        //    return _iMapper.Map<ProductDetailViewDto[]>(categoryBasedProducts);
        //}
    }
}
