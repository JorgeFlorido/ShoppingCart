using ShoppingCart.Data;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public static class CustomerMapperExtension
    {
        public static IEnumerable<CustomerViewModel> ConvertToCustomerViewModel(this IEnumerable<Customer> customers)
        {
            IList<CustomerViewModel> customerViewModel = new List<CustomerViewModel>();

            foreach (Customer c in customers)
            {
                customerViewModel.Add(c.ConvertToCustomerViewModel());
            }

            return customerViewModel;
        }

        public static CustomerViewModel ConvertToCustomerViewModel(this Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.Id = customer.Id;
            customerViewModel.Name = customer.Name;

            return customerViewModel;
        }
    }
}
