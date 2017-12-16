using ShoppingCart.Data;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerListViewModel GetAllCustomers()
        {
            CustomerListViewModel customerListVM = new CustomerListViewModel();

            try
            {
                IEnumerable<Customer> customers = _customerRepository.GetAll();
                customerListVM.userList = customers.ConvertToCustomerViewModel();
                customerListVM.selectedUser = 0;
            }
            catch (Exception)
            {
            }

            return customerListVM;
        }
    }
}
