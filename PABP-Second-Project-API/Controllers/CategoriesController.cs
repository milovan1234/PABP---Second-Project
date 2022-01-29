using AutoMapper;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using PABP_Second_Project_API.Models;
using PABP_Second_Project_API.Services;

namespace PABP_Second_Project_API.Controllers
{
    /// <summary>
    /// Categories controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for products controller.
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="mapper"></param>
        public CategoriesController(ICategoryService categoryService,
            IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get all categories from the system.
        /// </summary>
        /// <returns>List of all categories.</returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetProducts()
        {
            return Ok(this._mapper.Map<IList<CategoryVM>>(this._categoryService.GetCategories()));
        }

        /// <summary>
        /// Create category.
        /// </summary>
        /// <param name="category">Category model.</param>
        /// <returns>Created category.</returns>
        [HttpPost]
        [Route("")]
        public IActionResult CreateProduct([FromBody] CategoryVM category)
        {
            return Ok(this._mapper.Map<CategoryVM>(this._categoryService.CreateCategory(this._mapper.Map<Category>(category))));
        }

        /// <summary>
        /// Update category for specified category identifier.
        /// </summary>
        /// <param name="categoryId">Category identifier.</param>
        /// <param name="category">Category model.</param>
        /// <returns>Updated category.</returns>
        [HttpPut]
        [Route("{categoryId}")]
        public IActionResult UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryVM category)
        {
            return Ok(this._mapper.Map<CategoryVM>(this._categoryService.UpdateCategory(categoryId, this._mapper.Map<Category>(category))));
        }

        /// <summary>
        /// Delete category for specified category identifier.
        /// </summary>
        /// <param name="categoryId">Category identifier.</param>
        [HttpDelete]
        [Route("{categoryId}")]
        public IActionResult DeleteCategory([FromRoute] int categoryId)
        {
            this._categoryService.DeleteCategory(categoryId);
            return Ok();
        }
    }
}
