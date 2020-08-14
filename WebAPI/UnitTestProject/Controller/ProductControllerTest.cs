using BusinessLayer;
using EntityLayer.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace UnitTestProject.Controller
{
    [TestClass]
    public class ProductControllerTest
    {
        ProductController _productController;
        Mock<IProductManager> _iProductManagerMock;
        Mock<ILogger<ProductController>> _iLoggerMock;

        [TestInitialize]
        public void ProductControllerInitialize()
        {
            _iProductManagerMock = new Mock<IProductManager>();
            _iLoggerMock = new Mock<ILogger<ProductController>>();
        }

        [TestMethod]
        public void GetProducts_WhenSuccessfull_ReturnProductList()
        {
            List<ProductListViewDto> products = new List<ProductListViewDto>();
            ProductListViewDto product1 = new ProductListViewDto { ProductId = 1, ProductName = "TestProduct_1", ProductDescription = "TestProductDescription_1", UnitPrice = 1800 };
            ProductListViewDto product2 = new ProductListViewDto { ProductId = 2, ProductName = "TestProduct_2", ProductDescription = "TestProductDescription_2", UnitPrice = 2200 };
            products.Add(product1);
            products.Add(product2);

            //mock setup
            _iProductManagerMock.Setup<Task<IEnumerable<ProductListViewDto>>>(s => s.GetAllProductDetails())
                .Returns(Task.FromResult<IEnumerable<ProductListViewDto>>(products));
            _productController = new ProductController(_iProductManagerMock.Object, _iLoggerMock.Object);

            Task<IActionResult> result = _productController.GetProducts();

            OkObjectResult okResult = (OkObjectResult)result.Result;
            List<ProductListViewDto> list = (List<ProductListViewDto>)okResult.Value;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("TestProduct_1", list[0].ProductName);
            Assert.AreEqual(1800, list[0].UnitPrice);

        }

        [TestMethod]
        public void GetProduct_WhenSuccessfull_ReturnProduct()
        {
            ProductDetailViewDto product = new ProductDetailViewDto { ProductId = 1, ProductName = "TestProduct", ProductDescription = "TestProductDescription", UnitPrice = 1800 };

            //mock setup
            _iProductManagerMock.Setup<Task<ProductDetailViewDto>>(s => s.GetProductDetailsById(1))
                .Returns(Task.FromResult<ProductDetailViewDto>(product));
            _productController = new ProductController(_iProductManagerMock.Object, _iLoggerMock.Object);

            Task<IActionResult> result = _productController.Get(1);

            OkObjectResult okResult = (OkObjectResult)result.Result;
            ProductDetailViewDto resultProduct = (ProductDetailViewDto)okResult.Value;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual("TestProduct", resultProduct.ProductName);
            Assert.AreEqual(1800, resultProduct.UnitPrice);
        }

        [TestMethod]
        public void GetProductByCategory_WhenSuccessfull_ReturnProductListBasedOnCategoryId()
        {
            //check with Randheer
            List<ProductListViewDto> products = new List<ProductListViewDto>();
            ProductListViewDto product1 = new ProductListViewDto { ProductId = 1, ProductName = "TestProduct_1", ProductDescription = "TestProductDescription_1", UnitPrice = 1800 };
            ProductListViewDto product2 = new ProductListViewDto { ProductId = 2, ProductName = "TestProduct_2", ProductDescription = "TestProductDescription_2", UnitPrice = 2200 };
            products.Add(product1);
            products.Add(product2);

            //mock setup
            _iProductManagerMock.Setup<Task<IEnumerable<ProductListViewDto>>>(s => s.GetProductsByCategory(2))
                .Returns(Task.FromResult<IEnumerable<ProductListViewDto>>(products));
            _productController = new ProductController(_iProductManagerMock.Object, _iLoggerMock.Object);

            Task<IActionResult> result = _productController.GetProductsByCategory(2);

            OkObjectResult okResult = (OkObjectResult)result.Result;
            List<ProductListViewDto> list = (List<ProductListViewDto>)okResult.Value;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("TestProduct_1", list[0].ProductName);
            Assert.AreEqual(1800, list[0].UnitPrice);

        }
    }
}
