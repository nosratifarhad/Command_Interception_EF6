using Microsoft.AspNetCore.Mvc;
using CommandInterceptionWebApplication.InputModels.ProductInputModels;
using CommandInterceptionWebApplication.Services.Contracts;

namespace CommandInterceptionWebApplication.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields
        private readonly IProductServices _productServices;

        #endregion Fields

        #region Ctor

        public ProductsController(IProductServices productServices)
        {
            this._productServices = productServices;
        }

        #endregion Ctor

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/products")]
        public async ValueTask<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var productVMs = await _productServices.GetProductsAsync(cancellationToken);

            return Ok(productVMs);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/products")]
        public async ValueTask<IActionResult> CreateProduct(CreateProductInputModel command, CancellationToken cancellationToken)
        {
            int productId = await _productServices.CreateProductAsync(command, cancellationToken);

            return CreatedAtRoute(nameof(GetProduct), new { productId = productId }, new { ProductId = productId });
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/products/{productId:int}", Name = nameof(GetProduct))]
        public async ValueTask<IActionResult> GetProduct(int productId, CancellationToken cancellationToken)
        {
            var productVM = await _productServices.GetProductAsync(productId, cancellationToken);

            return Ok(productVM);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("/api/v1/products/{productId:int}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductInputModel command, CancellationToken cancellationToken)
        {
            if (productId != command.ProductId)
                return BadRequest("Bad Request Message");

            await _productServices.UpdateProductAsync(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("/api/v1/products/{productId:int}")]
        public async Task<IActionResult> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            await _productServices.DeleteProductAsync(productId, cancellationToken);

            return NoContent();
        }

    }
}
