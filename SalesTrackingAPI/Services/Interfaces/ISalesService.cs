using SalesTrackingAPI.Models;

namespace SalesTrackingAPI.Services.Interfaces
{
	public interface ISalesService
	{
		Task<List<Sale>> GetSalesAsync(DateTime? startDate, DateTime? endDate);
		Task<Sale> CreateSaleAsync(Sale sale);
	}
}
