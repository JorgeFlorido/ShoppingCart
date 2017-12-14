using Moq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Web.Controllers;
using ShoppingCart.Service;
using ShoppingCart.Data;

namespace ShoppingCart.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var productService = new Mock<IProductService>();
            var customerService = new Mock<ICustomerService>();

            // Arrange
            ProductController controller = new ProductController(productService.Object, customerService.Object);

            // Act
            ViewResult result = controller.ProductList() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
