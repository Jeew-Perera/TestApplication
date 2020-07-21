using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DAProduct : IDAProduct
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public DAProduct(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public List<Product> GetAllProductDetails()
        {
            List<Product> products = null;
            return products = _context.Product.Include(p => p.Category).ToList();
            /*var products = _context.Product.ToList();
            var productsViewModel = new List<ProductViewModel>();
            return _iMapper.Map<IEnumerable<ProductViewModel>>(products).ToList();*/

        }
        public ProductViewModel GetProductDetailsById(int productId)
        {
            var product = _context.Product.Where(p => p.ProductId == productId).FirstOrDefault();
            var productViewModel = _iMapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            //var products = _context.Product.Where(p => p.CategoryId == categoryId);
            //var productsViewModel = _iMapper.Map<ProductViewModel>(products);
            //return _iMapper.Map<IEnumerable<ProductViewModel>>(products).ToList();
            return _context.Product.Where(p => p.CategoryId == categoryId).ToList();
        }

    }
}
