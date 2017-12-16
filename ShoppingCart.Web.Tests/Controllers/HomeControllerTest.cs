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

            // Arrange
            ProductController controller = new ProductController(productService.Object);

            // Act
            ViewResult result = controller.ProductList(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
