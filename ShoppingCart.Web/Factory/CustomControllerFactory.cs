using ShoppingCart.Data;
using ShoppingCart.Service;
using System;
using System.Collections.Generic;
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
            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));

            switch (controllerName)
            {
                case "User":

                    ICustomerRepository customerRepository = new DbCustomerAdapter();
                    ICustomerService customerService = new CustomerService(customerRepository);

                    return Activator.CreateInstance(controllerType, customerService) as Controller;


                case "Product":

                    IProductRepository productRepository = new DbProductAdapter();
                    IPurchaseRepository purchaseRepository = new DbPurchaseAdapter();
                    IProductService productService = new ProductService(productRepository, purchaseRepository);

                    return Activator.CreateInstance(controllerType, productService) as Controller;

                case "Purchase":

                    IPurchaseRepository customerPurchaseRepository = new DbPurchaseAdapter();
                    IPurchaseService purchaseService = new PurchaseService(customerPurchaseRepository);

                    ICustomerRepository customerCartRepository = new DbCustomerAdapter();
                    ICustomerService customerCartService = new CustomerService(customerCartRepository);

                    return Activator.CreateInstance(controllerType, purchaseService, customerCartService) as Controller;

                default:
                    break;
            }

            return Activator.CreateInstance(controllerType, "") as Controller;          
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