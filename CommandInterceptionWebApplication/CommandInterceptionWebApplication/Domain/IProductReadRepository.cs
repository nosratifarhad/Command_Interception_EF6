using CommandInterceptionWebApplication.Domain.Entitys;

namespace CommandInterceptionWebApplication.Domain
{
    public interface IProductReadRepository
    {
        Task<Product> GetProductAsync(int productId , CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken);

        Task<bool> IsExistProductAsync(int productId, CancellationToken cancellationToken);
    }
}
