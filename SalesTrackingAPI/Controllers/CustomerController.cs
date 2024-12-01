using Microsoft.AspNetCore.Mvc;
using SalesTrackingAPI.Services.Interfaces;

namespace SalesTrackingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		// Constructor to inject the customer service
		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		// GET: api/customer
		[HttpGet]
		public IActionResult GetAllCustomers()
		{
			var customers = _customerService.GetAllCustomers();
			return Ok(customers); 
		}
	}

}