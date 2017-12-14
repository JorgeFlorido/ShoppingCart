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
            IDatabaseContext productContext = new DbProductAdapter();
            IDatabaseContext purchasecontext = new DbPurchaseAdapter();
            IDatabaseContext customerContext = new DbCustomerAdapter();

            IRepository<Products> productRepository = new Repository<Products>(productContext);
            IRepository<Purchase> purchaseRepository = new Repository<Purchase>(purchasecontext);
            IRepository<Customer> customerRepository = new Repository<Customer>(customerContext);

            IProductService productService = new ProductService(productRepository, purchaseRepository);
            ICustomerService customerService = new CustomerService(customerRepository);

            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));
            IController controller = Activator.CreateInstance(controllerType, productService, customerService) as Controller;

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