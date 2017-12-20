using Moq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Web.Controllers;
using ShoppingCart.Service;

namespace ShoppingCart.Web.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void UserLogin()
        {
            // Arrange
            var customerService = new Mock<ICustomerService>();
            UserController controller = new UserController(customerService.Object);

            // Act
            ViewResult result = controller.UserLogin() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
