namespace ShoppingCart.Service
{
    public class ProductViewModel : IProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public int QuantityToBuy { get; set; }
        public int BuyerId { get; set; }
    }
}
