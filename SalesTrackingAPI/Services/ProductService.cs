// Services/ProductService.cs
using SalesTrackingAPI.Data;
using SalesTrackingAPI.Models;
using SalesTrackingAPI.Services.Interfaces;

namespace YourNamespace.Services
{
	public class ProductService:IProductService
	{
		// Assuming InMemoryData is the collection where products are stored
		private readonly List<Product> _products = InMemoryData.Products;

		// Method to get all products
		public IEnumerable<Product> GetAllProducts()
		{
			return _products;
		}

		// Method to get a product by ID
		public Product GetProductById(int id)
		{
			return _products.FirstOrDefault(p => p.Id == id);
		}

		public async Task<Product> UpdateProductAsync(Product product)
		{
			// Find the existing product in the list
			var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);

			if (existingProduct == null)
				return null; // Or throw an exception if preferred

			// Check for duplicates in the collection excluding the current product
			if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
				throw new InvalidOperationException("Duplicate product name is not allowed.");

			// Update the existing product properties
			existingProduct.Name = product.Name;
			existingProduct.Manufacturer = product.Manufacturer;
			existingProduct.Style = product.Style;
			existingProduct.PurchasePrice = product.PurchasePrice;
			existingProduct.SalePrice = product.SalePrice;
			existingProduct.QtyOnHand = product.QtyOnHand;
			existingProduct.CommissionPercentage = product.CommissionPercentage;

			// Simulate async operation (in case of DB interaction, remove async here)
			await Task.CompletedTask;

			// Return the updated product
			return existingProduct;
		}
	}
}
