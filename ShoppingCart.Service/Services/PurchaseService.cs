using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Service
{
    public class PurchaseService
    {
        private IRepository<Purchase> _purchaseRepository;

        public PurchaseService(IRepository<Purchase> purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public IEnumerable<PurchaseViewModel> GetUserPurchases(int UserId)
        {
            IEnumerable<PurchaseViewModel> purchaseList = new List<PurchaseViewModel>();

            try
            {
                IEnumerable<Purchase> purchases = _purchaseRepository.GetAll();
                purchaseList = purchases.ConvertToPurchaseViewModel();
            }
            catch (Exception)
            {
            }

            return purchaseList.Where(x => x.CustomerID == UserId);
        }
    }
}
