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

                    IDatabaseContext customerContext = new DbCustomerAdapter();

                    IRepository<Customer> customerRepository = new Repository<Customer>(customerContext);

                    ICustomerService customerService = new CustomerService(customerRepository);

                    return Activator.CreateInstance(controllerType, customerService) as Controller;

                case "Product":

                    IDatabaseContext productContext = new DbProductAdapter();
                    IDatabaseContext purchasecontext = new DbPurchaseAdapter();

                    IRepository<Products> productRepository = new Repository<Products>(productContext);
                    IRepository<Purchase> purchaseRepository = new Repository<Purchase>(purchasecontext);

                    IProductService productService = new ProductService(productRepository, purchaseRepository);
                    return Activator.CreateInstance(controllerType, productService) as Controller;
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