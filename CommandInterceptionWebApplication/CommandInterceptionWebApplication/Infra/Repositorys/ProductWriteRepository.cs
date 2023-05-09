using CommandInterceptionWebApplication.Domain;
using CommandInterceptionWebApplication.Domain.Entitys;

namespace CommandInterceptionWebApplication.Infra.Repositorys
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        public async Task<int> CreateProductAsync(Product product)
        {
            await Task.Delay(1000);
            return Random.Shared.Next();
        }

        public async Task DeleteProductAsync(int productId)
        {
            await Task.Delay(1000);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await Task.Delay(1000);
        }
    }
}
