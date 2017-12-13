namespace ShoppingCart.Service
{
    public interface IPurchaseViewModel
    {
        int Id { get; set; }
        int ProductID { get; set; }
        int CustomerID { get; set; }
        bool Finished { get; set; }
    }
}
