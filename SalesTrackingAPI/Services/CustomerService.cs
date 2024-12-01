using SalesTrackingAPI.Services.Interfaces;

using SalesTrackingAPI.Models;

namespace SalesTrackingAPI.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly List<Customer> _customers = new List<Customer>();

		public CustomerService()
		{
			// Seed with sample data for testing
			_customers.Add(new Customer { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = "555-1234", StartDate = Convert.ToDateTime("2021-01-01") });
			_customers.Add(new Customer { Id = 2, FirstName = "Jane", LastName = "Doe", Address = "456 Oak St", Phone = "555-5678", StartDate = Convert.ToDateTime("2021-01-02") });
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _customers;
		}

	}
}

