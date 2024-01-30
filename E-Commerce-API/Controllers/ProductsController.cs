using E_Commerce.Services;
using E_Commerce_CORE_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using E_Commerce.Data.Entities;

namespace E_Commerce_API.Controllers
{
	[ApiController]
	[Route ("api/[Controller]")]
	public class ProductsController : ControllerBase
	{
		//use service here instead of repo
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{

			_productService = productService;

		}


		[HttpGet]
		[Route("AllProducts")]
		public async Task<IActionResult> GetProducts()
		{

			var products = await _productService.GetAllProductsWithCategories();

			
			return Ok(products);
		
		}


		[HttpGet("{id}")]
		public async Task<IActionResult>GetProduct(int id)
		{
			var product = await _productService.GetProductById(id);


			if (product != null)
			{



				return Ok(product);


			}
			else
			{
				return NotFound();
			}
		}


		
		[HttpPost]
		public async Task<IActionResult> AddNewProduct(ProductInStore newProduct)
		{

			if (ModelState.IsValid)
			{


				await _productService.AddProduct(newProduct);

				return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);

			}
			return BadRequest();
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, ProductInStore product)
		{
			await _productService.EditProduct(id, product);
			return NoContent();
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			if (ModelState.IsValid)
			{


				await _productService.DeleteProduct(id);
				return NoContent();
			}

			return BadRequest();

		}

	}
}
