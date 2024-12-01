using Microsoft.AspNetCore.Mvc;
using SalesTrackingAPI.Models;
using SalesTrackingAPI.Services.Interfaces;

namespace SalesTrackingAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult GetAllProducts()
		{
			return Ok(_productService.GetAllProducts());
		}

		[HttpGet("{id}")]
		public IActionResult GetProductById(int id)
		{
			var product = _productService.GetProductById(id);
			if (product == null)
				return NotFound();
			return Ok(product);
		}

		// PUT: api/Product/1
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
		{
			if (id != product.Id)
				return BadRequest("Product ID mismatch.");

			try
			{
				var updatedProduct = await _productService.UpdateProductAsync(product);
				if (updatedProduct == null)
					return NotFound();

				return Ok(updatedProduct);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}
	}

}
