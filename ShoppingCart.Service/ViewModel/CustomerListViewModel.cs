using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class CustomerListViewModel
    {
        public IEnumerable<CustomerViewModel> userList;
        public int currentUser;
    }
}
