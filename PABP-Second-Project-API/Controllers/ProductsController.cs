using AutoMapper;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PABP_Second_Project_API.Filters;
using PABP_Second_Project_API.Models;
using PABP_Second_Project_API.Services;

namespace PABP_Second_Project_API.Controllers
{
    /// <summary>
    /// Products controller.
    /// </summary>
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for products controller.
        /// </summary>
        /// <param name="productsService"></param>
        /// <param name="mapper"></param>
        public ProductsController(IProductService productsService,
            IMapper mapper)
        {
            this._productsService = productsService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get all products from the system.
        /// </summary>
        /// <returns>List of all products.</returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetProducts()
        {
            return Ok(this._mapper.Map<IList<ProductVM>>(this._productsService.GetProducts()));
        }

        /// <summary>
        /// Create product.
        /// </summary>
        /// <param name="product">Product model.</param>
        /// <returns>Created product.</returns>
        [HttpPost]
        [Route("")]
        public IActionResult CreateProduct([FromBody]ProductCreateVM product)
        {
            return Ok(this._mapper.Map<ProductVM>(this._productsService.CreateProduct(this._mapper.Map<Product>(product))));
        }

        /// <summary>
        /// Update product for specified product identifier.
        /// </summary>
        /// <param name="productId">Product identifier.</param>
        /// <param name="product">Product model.</param>
        /// <returns>Updated product.</returns>
        [HttpPut]
        [Route("{productId}")]
        public IActionResult UpdateProduct([FromRoute]int productId, [FromBody]ProductVM product)
        {
            return Ok(this._mapper.Map<ProductVM>(this._productsService.UpdateProduct(productId, this._mapper.Map<Product>(product))));
        }

        /// <summary>
        /// Delete product for specified product identifier.
        /// </summary>
        /// <param name="productId">Product identifier.</param>
        [HttpDelete]
        [Route("{productId}")]
        public IActionResult DeleteProduct([FromRoute]int productId)
        {
            this._productsService.DeleteProduct(productId);
            return Ok();
        }
    }
}
