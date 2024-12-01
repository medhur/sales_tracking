using SalesTrackingAPI.Data;
using SalesTrackingAPI.Models;
using SalesTrackingAPI.Services.Interfaces;

namespace SalesTrackingAPI.Services
{
	public class SalesService : ISalesService
	{
		private readonly List<Sale> _sales;
		private readonly List<Product> _products;
		private readonly List<Customer> _customers;
		private readonly List<Salesperson> _salespeople;

		public SalesService()
		{
			// Use data from InMemoryData
			_sales = InMemoryData.Sales;
			_products = InMemoryData.Products;
			_customers = InMemoryData.Customers;
			_salespeople = InMemoryData.Salespersons;
		}

		// Get all sales with optional date range filter
		public Task<List<Sale>> GetSalesAsync(DateTime? startDate, DateTime? endDate)
		{
			var salesQuery = _sales.AsQueryable();

			if (startDate.HasValue)
			{
				salesQuery = salesQuery.Where(s => s.SalesDate >= startDate.Value);
			}

			if (endDate.HasValue)
			{
				salesQuery = salesQuery.Where(s => s.SalesDate <= endDate.Value);
			}

			return Task.FromResult(salesQuery.ToList());
		}

		public async Task<Sale> CreateSaleAsync(Sale sale)
		{
			// Validate Product
			var product = _products.FirstOrDefault(p => p.Id == sale.ProductId);
			if (product == null)
				throw new ArgumentException("Invalid Product ID");

			// Validate Customer
			var customer = _customers.FirstOrDefault(c => c.Id == sale.CustomerId);
			if (customer == null)
				throw new ArgumentException("Invalid Customer ID");

			// Validate Salesperson
			var salesperson = _salespeople.FirstOrDefault(s => s.Id == sale.SalespersonId);
			if (salesperson == null)
				throw new ArgumentException("Invalid Salesperson ID");

			// Ensure product has enough stock
			if (product.QtyOnHand <= 0)
				throw new InvalidOperationException("Insufficient product stock");

			// Update product stock
			product.QtyOnHand -= 1;

			// Create Sale
			var newSale = new Sale
			{
				Id = _sales.Count + 1,  // You may want to use a different method to get the new ID (e.g., database auto-increment)
				ProductId = sale.ProductId,
				CustomerId = sale.CustomerId,
				SalespersonId = sale.SalespersonId,
				SalesDate = sale.SalesDate,
				Price = sale.Price
			};

			// Add to collection
			_sales.Add(newSale);

			return await Task.FromResult(newSale);
		}
	}
}
