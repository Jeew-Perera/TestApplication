using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer.Models;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBusinessProduct _iBusinessProduct;

        public ProductController(IBusinessProduct iBusinessProduct)
        {
            _iBusinessProduct = iBusinessProduct;
        }

        [HttpGet]
        [Route("Products")]
        public List<Product> GetProducts()
        {
            //BusinessProduct bp = new BusinessProduct();
            return _iBusinessProduct.GetAllProductDetails().ToList();
            //List<Product> products = null;
            //return products = _context.Product.ToList();
        }

        [HttpGet("{productId}")]
        //[Route("Prods")]
        public ProductViewModel Get(int productId)
        {
            //BusinessProduct bp = new BusinessProduct();
            return _iBusinessProduct.GetProductDetailsById(productId);
            //List<Product> products = null;
            //return products = _context.Product.ToList();
        }

        [Route("[action]/{categoryId}")]
        [HttpGet]
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _iBusinessProduct.GetProductsByCategory(categoryId);
        }
    }
}
