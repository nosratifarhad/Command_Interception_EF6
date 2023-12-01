using CommandInterceptionWebApplication.Domain.Entitys;

namespace CommandInterceptionWebApplication.Domain
{
    public interface IProductWriteRepository
    {
        Task<int> CreateProductAsync(Product product, CancellationToken cancellationToken);

        Task UpdateProductAsync(Product product, CancellationToken cancellationToken);

        Task DeleteProductAsync(int productId, CancellationToken cancellationToken);
    }
}
