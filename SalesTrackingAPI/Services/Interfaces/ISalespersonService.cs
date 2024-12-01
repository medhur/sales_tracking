using SalesTrackingAPI.Models;

namespace SalesTrackingAPI.Services.Interfaces
{
	public interface ISalespersonService
	{
		IEnumerable<Salesperson> GetAllSalespersons();
		Salesperson GetSalespersonById(int id);
		Task<Salesperson> UpdateSalespersonAsync(Salesperson salesperson);
		Task<List<CommissionReport>> GetQuarterlyCommissionReportAsync();
	}
}
