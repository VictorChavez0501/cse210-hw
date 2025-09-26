namespace OnlineOrdering
{
    public class Customer
    {
        private string _name;
        private Address _address;

        public string Name { get => _name; private set => _name = value; }
        public Address Address { get => _address; private set => _address = value; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public string GetShippingLabel()
        {
            return $"{Name}\n{Address}";
        }
    }
}
