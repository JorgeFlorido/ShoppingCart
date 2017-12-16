using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public interface IPurchaseService
    {
        IEnumerable<PurchaseViewModel> GetUserPurchases(int UserId);
        void FinishPurchases(IEnumerable<PurchaseViewModel> purchases);
    }
}
