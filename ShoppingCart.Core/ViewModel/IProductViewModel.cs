namespace ShoppingCart.Core
{
    public interface IProductViewModel
    {
        string Description { get; set; }
        int Id { get; set; }
        bool IsAvailable { get; set; }
        string Name { get; set; }
        int Quantity { get; set; }
    }
}