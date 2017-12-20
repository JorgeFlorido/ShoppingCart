using ShoppingCart.Data;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public static class PurchaseMapperExtension
    {
        public static IEnumerable<PurchaseViewModel> ConvertToPurchaseViewModel(this IEnumerable<Purchase> purchases)
        {
            IList<PurchaseViewModel> purchaseViewModel = new List<PurchaseViewModel>();

            foreach (Purchase p in purchases)
            {
                purchaseViewModel.Add(p.ConvertToPurchaseViewModel());
            }

            return purchaseViewModel;
        }

        public static PurchaseViewModel ConvertToPurchaseViewModel(this Purchase purchase)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();

            purchaseViewModel.Id = purchase.Id;
            purchaseViewModel.ProductID = purchase.ProductID;
            purchaseViewModel.ProductName = purchase.Products.Name;
            purchaseViewModel.CustomerID = purchase.CustomerID;
            purchaseViewModel.Finished = purchase.Finished;
            purchaseViewModel.Quantity = purchase.Quantity;

            return purchaseViewModel;
        }

        public static Purchase ConvertToEntity(this PurchaseViewModel purchaseVM)
        {
            Purchase purchase = new Purchase();

            purchase.Id = purchaseVM.Id;
            purchase.ProductID = purchaseVM.ProductID;
            purchase.CustomerID = purchaseVM.CustomerID;
            purchase.Finished = purchaseVM.Finished;
            purchase.Quantity = purchaseVM.Quantity;

            return purchase;
        }
    }
}
