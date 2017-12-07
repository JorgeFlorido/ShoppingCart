using ShoppingCart.Data;
using ShoppingCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ShoppingCart.Web
{
    public class CustomControllerFactory : IControllerFactory
    {
        private readonly string _controllerNamespace;
        
        public CustomControllerFactory(string controllerNamespace)
        {
            _controllerNamespace = controllerNamespace;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            ShopEntities context = new ShopEntities();
            IRepository<Products> productRepository = new Repository<Products>(context);
            IProductService productService = new ProductService(productRepository);
            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));
            IController controller = Activator.CreateInstance(controllerType, productRepository, productService) as Controller;
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}