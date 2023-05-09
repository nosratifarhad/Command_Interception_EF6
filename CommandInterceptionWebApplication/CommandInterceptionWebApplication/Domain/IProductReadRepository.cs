using CommandInterceptionWebApplication.Domain.Entitys;

namespace CommandInterceptionWebApplication.Domain
{
    public interface IProductReadRepository
    {
        Task<Product> GetProductAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<bool> IsExistProductAsync(int productId);
    }
}
