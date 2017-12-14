namespace ShoppingCart.Service
{
    public interface IProductViewModel
    {
        string Description { get; set; }
        int Id { get; set; }
        bool IsAvailable { get; set; }
        string Name { get; set; }
        int Quantity { get; set; }
        int QuantityToBuy { get; set; }
        int BuyerId { get; set; }
    }
}