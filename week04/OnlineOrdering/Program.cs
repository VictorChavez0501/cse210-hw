using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customer 1 (USA)
            Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("Alice Johnson", address1);

            Order order1 = new Order(customer1);
            order1.AddItem(new Product("Laptop", "P001", 999.99m), 1);
            order1.AddItem(new Product("Mouse", "P002", 25.50m), 2);

            // Customer 2 (International)
            Address address2 = new Address("456 High St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Carlos Gomez", address2);

            Order order2 = new Order(customer2);
            order2.AddItem(new Product("Keyboard", "P003", 45.00m), 1);
            order2.AddItem(new Product("Monitor", "P004", 250.00m), 1);

            // Print Order 1
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order1.GetTotalCost():C}\n");

            // Print Order 2
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order2.GetTotalCost():C}\n");
        }
    }
}
