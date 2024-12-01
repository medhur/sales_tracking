namespace SalesTrackingAPI.Models
{
	public class Sale
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int CustomerId { get; set; }
		public int SalespersonId { get; set; }
		public DateTime SalesDate { get; set; }
		public decimal Price { get; set; }
		public decimal Commission { get; set; }
		public decimal Amount { get; set; }

	}

}
