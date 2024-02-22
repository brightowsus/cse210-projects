using System;
using System.Collections.Generic;

// Define the Product class to represent a product
public class Product
{
    // Properties
    public string Name { get; set; }
    public double Price { get; set; }

    // Constructor
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

// Define the Order class to represent an order
public class Order
{
    // Properties
    private List<Product> products;

    // Constructor
    public Order()
    {
        products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total price of the order
    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.Price;
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some sample products
        Product product1 = new Product("Product 1", 10.99);
        Product product2 = new Product("Product 2", 5.99);

        // Create an order and add products to it
        Order order = new Order();
        order.AddProduct(product1);
        order.AddProduct(product2);

        // Calculate and display the total price of the order
        double totalPrice = order.CalculateTotalPrice();
        Console.WriteLine($"Total Price: {totalPrice}");
    }
}
