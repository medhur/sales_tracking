using Microsoft.AspNetCore.Mvc;
using SalesTrackingAPI.Models;
using SalesTrackingAPI.Services.Interfaces;

namespace SalesTrackingAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SalespersonController : ControllerBase
	{
		private readonly ISalespersonService _salespersonService;

		public SalespersonController(ISalespersonService salespersonService)
		{
			_salespersonService = salespersonService;
		}

		[HttpGet]
		public IActionResult GetAllSalespersons()
		{
			return Ok(_salespersonService.GetAllSalespersons());
		}


		[HttpGet("{id}")]
		public IActionResult GetSalespersonById(int id)
		{
			var salesperson = _salespersonService.GetSalespersonById(id);
			if (salesperson == null)
				return NotFound();
			return Ok(salesperson);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSalesperson(int id, [FromBody] Salesperson salesperson)
		{
			if (id != salesperson.Id)
				return BadRequest("Salesperson ID mismatch.");

			try
			{
				var updatedSalesperson = await _salespersonService.UpdateSalespersonAsync(salesperson);
				if (updatedSalesperson == null)
					return NotFound();

				return Ok(updatedSalesperson);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}


		[HttpGet("commissions")]
		public async Task<IActionResult> GetCommissionReport()
		{
			try
			{
				var commissionReport = await _salespersonService.GetQuarterlyCommissionReportAsync();
				return Ok(commissionReport);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}