using Moq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Web.Controllers;
using ShoppingCart.Service;
using System.Web;
using System.Collections.Specialized;

namespace ShoppingCart.Web.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        private NameValueCollection values;

        [TestMethod]
        public void ProductList()
        {
            // Arrange
            values = new NameValueCollection
            {
                {"selectedUser", "2" }
            };

            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();

            request.Setup(q => q.QueryString).Returns(values);
            context.Setup(r => r.Request).Returns(request.Object);

            var productService = new Mock<IProductService>();
            ProductController controller = new ProductController(productService.Object);

            // Act
            ViewResult result = controller.ProductList() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
