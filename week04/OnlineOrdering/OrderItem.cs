namespace OnlineOrdering
{
    public class OrderItem
    {
        private Product _product;
        private int _quantity;

        public Product Product { get => _product; private set => _product = value; }
        public int Quantity { get => _quantity; private set => _quantity = value; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetSubtotal()
        {
            return Product.Price * Quantity;
        }

        public string GetPackingLabel()
        {
            return $"{Product.Name} ({Product.Id}) x{Quantity}";
        }
    }
}
