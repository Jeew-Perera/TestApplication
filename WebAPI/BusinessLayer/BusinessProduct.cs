using DataAccessLayer;
using DataAccessLayer.Models;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class BusinessProduct : IBusinessProduct
    {
        private IDAProduct _iDAProduct;

        public BusinessProduct(IDAProduct iDAProduct)
        {
            _iDAProduct = iDAProduct;
        }

        public List<Product> GetAllProductDetails()
        {
            return _iDAProduct.GetAllProductDetails().ToList();
        }

        public ProductViewModel GetProductDetailsById(int productId)
        {
            return _iDAProduct.GetProductDetailsById(productId);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _iDAProduct.GetProductsByCategory(categoryId);
        }
    }
}
