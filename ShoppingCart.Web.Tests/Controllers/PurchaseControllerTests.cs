using Moq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Web.Controllers;
using ShoppingCart.Service;

namespace ShoppingCart.Web.Tests.Controllers
{
    [TestClass]
    public class PurchaseControllerTests
    {
        [TestMethod]
        public void SelectUserCart()
        {
            // Arrange
            var customerService = new Mock<ICustomerService>();
            var purchaseService = new Mock<IPurchaseService>();
            PurchaseController controller = new PurchaseController(purchaseService.Object, customerService.Object);

            // Act
            ViewResult result = controller.SelectUserCart() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
