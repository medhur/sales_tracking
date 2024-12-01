using SalesTrackingAPI.Data;
using SalesTrackingAPI.Models;
using SalesTrackingAPI.Services.Interfaces;

namespace SalesTrackingAPI.Services
{
	public class SalespersonService : ISalespersonService
	{
		// Retrieve all salespersons from in-memory data
		public IEnumerable<Salesperson> GetAllSalespersons()
		{
			return InMemoryData.Salespersons;
		}

		// Retrieve a salesperson by their ID
		public Salesperson GetSalespersonById(int id)
		{
			return InMemoryData.Salespersons.FirstOrDefault(s => s.Id == id);
		}

		public async Task<Salesperson> UpdateSalespersonAsync(Salesperson salesperson)
		{
			// Find the existing salesperson in the list
			var existingSalesperson = InMemoryData.Salespersons.FirstOrDefault(s => s.Id == salesperson.Id);

			if (existingSalesperson == null)
				return null; // Or throw an exception if preferred

			// Check for duplicates in the collection excluding the current salesperson
			if (InMemoryData.Salespersons.Any(s => s.FirstName.Equals(salesperson.FirstName, StringComparison.OrdinalIgnoreCase)))
				throw new InvalidOperationException("Duplicate salesperson name is not allowed.");

			// Update the existing salesperson properties
			existingSalesperson.FirstName = salesperson.FirstName;
			existingSalesperson.LastName = salesperson.LastName;
			existingSalesperson.Phone = salesperson.Phone;
			existingSalesperson.Address = salesperson.Address;
			existingSalesperson.Manager = salesperson.Manager;
			existingSalesperson.StartDate = salesperson.StartDate;

			// Simulate async operation (in case of DB interaction, remove async here)
			await Task.CompletedTask;

			// Return the updated salesperson
			return existingSalesperson;
		}


		// Generate a quarterly commission report
		public async Task<List<CommissionReport>> GetQuarterlyCommissionReportAsync()
		{
			return await Task.Run(() =>
			{
				// Group sales by Salesperson and Quarter
				return InMemoryData.Sales
					.GroupBy(sale => new
					{
						sale.SalespersonId,
						Quarter = GetQuarter(sale.SalesDate)
					})
					.Select(group => new CommissionReport
					{
						Salesperson = InMemoryData.Salespersons.FirstOrDefault(sp => sp.Id == group.Key.SalespersonId),
						Quarter = group.Key.Quarter,
						TotalSales = group.Sum(sale => sale.Amount),
						Commission = group.Sum(sale => sale.Amount) * 0.1m // Example: 10% commission
					})
					.ToList();
			});
		}

		// Helper method to determine the quarter of a given date
		private static string GetQuarter(DateTime date)
		{
			return $"Q{((date.Month - 1) / 3) + 1} {date.Year}";
		}
	}
}
