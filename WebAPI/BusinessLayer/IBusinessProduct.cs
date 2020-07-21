using DataAccessLayer.Models;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IBusinessProduct
    {
        List<Product> GetAllProductDetails();
        ProductViewModel GetProductDetailsById(int productId);
        List<Product> GetProductsByCategory(int categoryId);
    }
}
