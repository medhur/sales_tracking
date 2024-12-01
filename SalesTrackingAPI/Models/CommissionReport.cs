namespace SalesTrackingAPI.Models
{
	public class CommissionReport
	{
		public Salesperson Salesperson { get; set; }
		public string Quarter { get; set; }
		public decimal TotalSales { get; set; }
		public decimal Commission { get; set; }
	}
}
