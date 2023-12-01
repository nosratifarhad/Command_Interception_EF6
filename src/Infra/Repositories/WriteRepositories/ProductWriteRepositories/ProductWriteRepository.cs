using CommandInterceptionWebApplication.Domain;
using CommandInterceptionWebApplication.Domain.Entitys;
using CommandInterceptionWebApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CommandInterceptionWebApplication.Infra.Repositories.WriteRepositories.ProductWriteRepositories
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        private DefaultDbContext _dbContext;

        public ProductWriteRepository(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _dbContext.Products.AddAsync(product, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.ProductId;
        }

        public async Task DeleteProductAsync(int productId, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync<Product>(e => e.ProductId == productId, cancellationToken);

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            _dbContext.Update<Product>(product);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
