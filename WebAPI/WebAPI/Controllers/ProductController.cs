using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _iProductManager;
        private readonly ILogger _iLogger;

        public ProductController(IProductManager iProductManager, ILogger<ProductController> iLogger)
        {
            _iProductManager = iProductManager;
            _iLogger = iLogger;
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProducts()
        {
            _iLogger.LogInformation("Start get all products");
            var products = await _iProductManager.GetAllProductDetails();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = await _iProductManager.GetProductDetailsById(productId);
            return Ok(product);
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var categoryBasedProduct = await _iProductManager.GetProductsByCategory(categoryId);
            return Ok(categoryBasedProduct);
        }
    }
}
