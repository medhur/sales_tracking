namespace SalesTrackingAPI.Data
{
	using SalesTrackingAPI.Models;
	using System;
	using System.Collections.Generic;

	public static class InMemoryData
	{
		public static List<Product> Products = new List<Product>
	{
		new Product { Id = 1, Name = "Mountain Bike", Manufacturer = "Brand A", Style = "MTB", PurchasePrice = 500, SalePrice = 700, QtyOnHand = 50, CommissionPercentage = 5 },
		new Product { Id = 2, Name = "Road Bike", Manufacturer = "Brand B", Style = "Road", PurchasePrice = 600, SalePrice = 900, QtyOnHand = 30, CommissionPercentage = 6 }
	};

		public static List<Salesperson> Salespersons = new List<Salesperson>
	{
		new Salesperson { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = "555-1234", StartDate = DateTime.Now.AddYears(-2), Manager = "Jane Smith" },
		new Salesperson { Id = 2, FirstName = "Alice", LastName = "Johnson", Address = "456 Elm St", Phone = "555-5678", StartDate = DateTime.Now.AddMonths(-6), Manager = "Jane Smith" }
	};

		public static List<Customer> Customers = new List<Customer>
	{
		new Customer { Id = 1, FirstName = "Charlie", LastName = "Brown", Address = "789 Oak St", Phone = "555-6789", StartDate = DateTime.Now.AddMonths(-12) },
		new Customer { Id = 2, FirstName = "David", LastName = "Wilson", Address = "101 Pine St", Phone = "555-9876", StartDate = DateTime.Now.AddMonths(-3) }
	};

		public static List<Sale> Sales = new List<Sale>
		{
			new Sale
			{
				Id = 1,
				ProductId = 1, 
                CustomerId = 1,
				SalespersonId = 1,
				SalesDate = DateTime.Now.AddDays(-10),
				Price = 700,
				Commission = 35,
				Amount = 1000m
			},
			new Sale
			{
				Id = 2,
				ProductId = 2, 
                CustomerId = 2,
				SalespersonId = 2,
				SalesDate = DateTime.Now.AddDays(-5),
				Price = 900,
				Commission = 54,
				Amount = 1000m
			}
		};
	}

}
