using CommandInterceptionWebApplication.Domain.Entitys;

namespace CommandInterceptionWebApplication.Domain
{
    public interface IProductWriteRepository
    {
        Task<int> CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int productId);
    }
}
