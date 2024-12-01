using Microsoft.AspNetCore.Mvc;
using SalesTrackingAPI.Services.Interfaces;
using SalesTrackingAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
	private readonly ISalesService _salesService;

	public SalesController(ISalesService salesService)
	{
		_salesService = salesService;
	}

	[HttpGet]
	public async Task<IActionResult> GetSales([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
	{
		var sales = await _salesService.GetSalesAsync(startDate, endDate);
		return Ok(sales);
	}

	[HttpPost]
	public async Task<IActionResult> CreateSale([FromBody] Sale sale)
	{
		var createdSale = await _salesService.CreateSaleAsync(sale);
		return CreatedAtAction(nameof(GetSales), new { id = createdSale.Id }, createdSale);
	}
}
