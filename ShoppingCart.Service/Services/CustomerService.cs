using ShoppingCart.Data;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
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

        public CustomerViewModel GetById(int id)
        {
            CustomerViewModel customerVM = new CustomerViewModel();

            try
            {
                Customer customer = _customerRepository.GetById(id);
                customerVM = customer.ConvertToCustomerViewModel();
            }
            catch (Exception)
            {
            }

            return customerVM;
        }
    }
}
