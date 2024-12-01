using SalesTrackingAPI.Models;

namespace SalesTrackingAPI.Services.Interfaces
{
	public interface ICustomerService
	{
		IEnumerable<Customer> GetAllCustomers();
	}
}
