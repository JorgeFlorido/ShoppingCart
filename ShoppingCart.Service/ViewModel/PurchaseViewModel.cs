namespace ShoppingCart.Service
{
    public class PurchaseViewModel : IPurchaseViewModel
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public bool Finished { get; set; }
    }
}
