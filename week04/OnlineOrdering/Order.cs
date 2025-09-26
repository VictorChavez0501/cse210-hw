using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<OrderItem> _items;
        private Customer _customer;

        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
        public Customer Customer { get => _customer; private set => _customer = value; }

        public Order(Customer customer)
        {
            Customer = customer;
            _items = new List<OrderItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            _items.Add(new OrderItem(product, quantity));
        }

        public decimal GetTotalCost()
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                total += item.GetSubtotal();
            }

            // Shipping: $5 if USA, $35 if not
            total += Customer.Address.IsUSA() ? 5 : 35;

            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var item in _items)
            {
                sb.AppendLine(item.GetPackingLabel());
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{Customer.GetShippingLabel()}";
        }
    }
}
