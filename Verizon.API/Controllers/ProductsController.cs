using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Verizon.Models.ViewModels;
using Verizon.Services;

namespace Verizon.API.Controllers
{
    /// <summary>
    /// Controler working with products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService _productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets all the products with calculated annual consts for yearly consumption
        /// </summary>
        /// <param name="annualConsumption">Annual consumption (kwh/year)</param>
        /// <returns>list of products</returns>
        [HttpGet("{annualConsumption}")]
        public IActionResult GetProducts(double annualConsumption)
        {
            var products = _productService.GetProducts();

            return Ok(products.Select(p => new ProductViewModel(p, annualConsumption)).OrderBy(q => q.AnnualCosts));
        }
    }
}