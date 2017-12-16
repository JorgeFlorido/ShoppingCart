using ShoppingCart.Data;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public IEnumerable<PurchaseViewModel> GetUserPurchases(int UserId)
        {
            IEnumerable<PurchaseViewModel> purchaseList = new List<PurchaseViewModel>();

            try
            {
                IEnumerable<Purchase> purchases = _purchaseRepository.GetUserPurchases(UserId);
                purchaseList = purchases.ConvertToPurchaseViewModel();
            }
            catch (Exception)
            {
            }

            return purchaseList;
        }

        public void FinishPurchases(IEnumerable<PurchaseViewModel> purchasesVM)
        {
            foreach (var pvm in purchasesVM)
            {
                var p = pvm.ConvertToEntity();
                p.Finished = true;
                _purchaseRepository.Update(p);
            }
        }
    }
}
