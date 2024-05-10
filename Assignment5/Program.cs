using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sale[] sales = new Sale[]
            {
                new Sale { Item = "Coffee", Customer = "Chana", PricePerItem = 15.0, Quantity = 1, Address = "123 Main St", ExpeditedShipping = false },
                new Sale { Item = "Tea", Customer = "Michal LLC", PricePerItem = 8.0, Quantity = 1, Address = "456 Elm St", ExpeditedShipping = true },
                new Sale { Item = "Smoothie", Customer = "Jeff LLC", PricePerItem = 20.0, Quantity = 6, Address = "789 Oak St", ExpeditedShipping = true },
                new Sale { Item = "Tea", Customer = "Kelcy", PricePerItem = 12.0, Quantity = 2, Address = "101 Pine St", ExpeditedShipping = false },
                new Sale { Item = "Lemonade", Customer = "Travis", PricePerItem = 10.0, Quantity = 2, Address = "302 Castaway Dr", ExpeditedShipping = true },
                new Sale { Item = "Ice Tea", Customer = "Leslie", PricePerItem = 15.0, Quantity = 4, Address = "46 Empire St", ExpeditedShipping = false },
                new Sale { Item = "Milkshake", Customer = "Amanda LLC", PricePerItem = 25.0, Quantity = 3, Address = "529 Champagne Dr", ExpeditedShipping = false }
            };

            var priceOver10 = sales.Where(s => s.PricePerItem > 10.0);
            var quant1DescPrice = sales.Where(s => s.Quantity == 1).OrderByDescending(s => s.PricePerItem);
            var teaNoExpedited = sales.Where(s => s.Item == "Tea" && s.ExpeditedShipping == false);
            var addressSalesOver100 = sales.Where(s => s.PricePerItem * s.Quantity > 100.0).Select(s => s.Address);
            var LLCCustomer = sales.Where(s => s.Customer.ToUpper().Contains("LLC")).Select(s => new
            {
                Item = s.Item,
                TotalPrice = s.PricePerItem * s.Quantity,
                Shipping = s.ExpeditedShipping ? s.Address + " EXPEDITE" : s.Address
            }).OrderBy(s => s.TotalPrice);


            Console.WriteLine("Items priced over $10:");
            foreach (var item in priceOver10)
            {
                Console.WriteLine($"Item: {item.Item}, Price:$ {item.PricePerItem}");
            }
            Console.WriteLine();

            Console.WriteLine("Items with a quantity of 1: ");
            foreach (var item in quant1DescPrice)
            {
                Console.WriteLine($"Item: {item.Item}, Quantity: {item.Quantity}, Price:$ {item.PricePerItem}");
            }
            Console.WriteLine();

            Console.WriteLine("Tea with no expedited shipping: ");
            foreach (var item in teaNoExpedited)
            {
                Console.WriteLine($"Item: {item.Item}, ExpeditedShipping: {item.ExpeditedShipping}");
            }
            Console.WriteLine();

            Console.WriteLine("Addresses of sales over $100: ");
            foreach (var address in addressSalesOver100)
            {
                Console.WriteLine($"Address: {address}");
            }
            Console.WriteLine();

            Console.WriteLine("Sales made to LLC customers: ");
            foreach (var item in LLCCustomer)
            {
                Console.WriteLine($"Item: {item.Item}, TotalPrice:$ {item.TotalPrice}, Shipping: {item.Shipping}");
            }
            Console.ReadKey();

        }
    }
}
