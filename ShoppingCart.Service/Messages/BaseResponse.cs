using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public void Confirm(bool ok, string message)
        {
            this.Success = ok;
            this.Message = message;
        }
    }
}
