namespace OnlineOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;

        public string Street { get => _street; private set => _street = value; }
        public string City { get => _city; private set => _city = value; }
        public string State { get => _state; private set => _state = value; }
        public string Country { get => _country; private set => _country = value; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        public bool IsUSA()
        {
            return Country.Trim().ToUpper() == "USA";
        }

        public override string ToString()
        {
            return $"{Street}\n{City}, {State}\n{Country}";
        }
    }
}
