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
                var purchase = _purchaseRepository.Get(pvm.Id);
                var product = _productRespository.Get(pvm.ProductID);

                product.Quantity = product.Quantity - pvm.Quantity;
                purchase.Finished = true;

                _purchaseRepository.Update(purchase);
                _productRespository.Update(product);
            }
        }
    }
}
