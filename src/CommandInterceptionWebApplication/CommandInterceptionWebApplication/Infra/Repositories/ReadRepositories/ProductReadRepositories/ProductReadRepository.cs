using CommandInterceptionWebApplication.Domain;
using CommandInterceptionWebApplication.Domain.Entitys;
using CommandInterceptionWebApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CommandInterceptionWebApplication.Infra.Repositories.ReadRepositories.ProductReadRepositories
{
    public class ProductReadRepository : IProductReadRepository
    {
        private DefaultDbContext _dbContext;

        public ProductReadRepository(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(e => e.ProductId == productId, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Products.ToList();
        }

        public async Task<bool> IsExistProductAsync(int productId, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.AnyAsync(e => e.ProductId == productId, cancellationToken);
        }
    }
}
