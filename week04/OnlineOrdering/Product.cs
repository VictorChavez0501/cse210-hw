namespace OnlineOrdering
{
    public class Product
    {
        private string _name;
        private string _id;
        private decimal _price;

        public string Name { get => _name; private set => _name = value; }
        public string Id { get => _id; private set => _id = value; }
        public decimal Price { get => _price; private set => _price = value; }

        public Product(string name, string id, decimal price)
        {
            Name = name;
            Id = id;
            Price = price;
        }
    }
}
