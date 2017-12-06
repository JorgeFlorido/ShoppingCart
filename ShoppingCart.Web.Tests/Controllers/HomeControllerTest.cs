using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Web;
using ShoppingCart.Web.Controllers;
using ShoppingCart.Service;
using ShoppingCart.Logic;


namespace ShoppingCart.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var productService = new Mock<IProductService>();
            var buyLogic = new Mock<IBuyLogic>();

            // Arrange
            HomeController controller = new HomeController(productService.Object, buyLogic.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
