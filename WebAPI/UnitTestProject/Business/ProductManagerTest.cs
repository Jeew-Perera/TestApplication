using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using EntityLayer.ProductDto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace UnitTestProject.Business
{
    [TestClass]
    public class ProductManagerTest
    {
        Mock<IUnitOfWork> _mockUnitOfWork;
        ProductManager productManager;
        ProductDetailViewDto productDetailViewDto;
        Mock<IProductRepository> _mokcProductRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            productDetailViewDto = new ProductDetailViewDto()
            {
                ProductId = 1,
                ProductName = "TestProduct",
                UnitPrice = 2000,
                ProductDescription = "This is test product",
                ImageUrl = ""
            };
            _mokcProductRepository = new Mock<IProductRepository>();
            _mokcProductRepository.Setup(m => m.GetProductDetailsById(1)).ReturnsAsync(productDetailViewDto);
            _mockUnitOfWork.Setup(m => m.ProductRepository).Returns(_mokcProductRepository.Object);
        }

        [TestMethod]
        public void GetProduct_WhenSuccessfull_ReturnProductDetail()
        {
            productManager = new ProductManager(_mockUnitOfWork.Object);
            Task<ProductDetailViewDto> productObject = productManager.GetProductDetailsById(1);

            var result = productObject.Result;

            Assert.AreEqual("TestProduct", result.ProductName);
            Assert.AreEqual(1, result.ProductId);
            Assert.AreEqual(2000, result.UnitPrice);
        }
    }
}
