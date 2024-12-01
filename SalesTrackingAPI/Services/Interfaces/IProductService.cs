using SalesTrackingAPI.Models;

namespace SalesTrackingAPI.Services.Interfaces
{
	public interface IProductService
	{
		IEnumerable<Product> GetAllProducts();
		Product GetProductById(int id);
		Task<Product> UpdateProductAsync(Product product);
	}
}
