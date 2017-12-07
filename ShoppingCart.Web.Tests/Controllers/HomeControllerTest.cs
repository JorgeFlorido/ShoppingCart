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
            var  = new Mock<IRepository<Products>>();
            var productService = new Mock<IProductService>();

            // Arrange
            HomeController controller = new HomeController(productService.Object, productRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
