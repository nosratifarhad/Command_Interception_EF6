using CommandInterceptionWebApplication.InputModels.ProductInputModels;
using CommandInterceptionWebApplication.ViewModels.ProductViewModels;

namespace CommandInterceptionWebApplication.Services.Contracts
{
    public interface IProductServices
    {
        Task<int> CreateProductAsync(CreateProductInputModel inputModel, CancellationToken cancellationToken);

        Task UpdateProductAsync(UpdateProductInputModel inputModel, CancellationToken cancellationToken);

        Task DeleteProductAsync(int productId, CancellationToken cancellationToken);

        ValueTask<ProductViewModel> GetProductAsync(int productId, CancellationToken cancellationToken);

        ValueTask<IEnumerable<ProductViewModel>> GetProductsAsync(CancellationToken cancellationToken);
    }
}
