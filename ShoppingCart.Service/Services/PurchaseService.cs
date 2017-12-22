using ShoppingCart.Data;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        private IProductRepository _productRespository;

        public PurchaseService(
            IPurchaseRepository purchaseRepository, 
            IProductRepository productRepository)
        {
            _purchaseRepository = purchaseRepository;
            _productRespository = productRepository;
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
                try
                {
                    var purchase = _purchaseRepository.Get(pvm.Id);
                    var product = _productRespository.Get(pvm.ProductID);

                    if (product != null && purchase != null)
                    {
                        // I would check here if the quantity is enough to finish de purchase
                        // but how to act in that case wasn't defined in the specs (cancel
                        // whole purchase or buy just available items), so I considered it
                        // out of the scope of the test. It's previously checked in frontend
                        // but anyway...

                        product.Quantity = product.Quantity - pvm.Quantity;
                        purchase.Finished = true;

                        _purchaseRepository.Update(purchase);
                        _productRespository.Update(product); 
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
