using Microsoft.Extensions.Options;
using CommandInterceptionWebApplication.Domain;
using CommandInterceptionWebApplication.Domain.Entitys;
using CommandInterceptionWebApplication.InputModels.ProductInputModels;
using CommandInterceptionWebApplication.Services.Contracts;
using CommandInterceptionWebApplication.ViewModels.ProductViewModels;

namespace CommandInterceptionWebApplication.Services
{
    public class ProductServices : IProductServices
    {
        #region Fields

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        #endregion Fields

        #region Ctor

        public ProductServices(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository)
        {
            this._productWriteRepository = productWriteRepository;
            this._productReadRepository = productReadRepository;
        }

        #endregion Ctor

        #region Implement

        public async ValueTask<ProductViewModel> GetProductAsync(int productId, CancellationToken cancellationToken)
        {
            if (productId <= 0)
                throw new NullReferenceException("Product Id Is Invalid");

            var product= await _productReadRepository.GetProductAsync(productId, cancellationToken).ConfigureAwait(false);
            if (product == null)
                return new ProductViewModel();

            var productViewModel = CreateProductViewModelFromProduct(product);

            return productViewModel;
        }

        public async ValueTask<IEnumerable<ProductViewModel>> GetProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetProductsAsync(cancellationToken).ConfigureAwait(false);

            if (products == null || products.Count() == 0)
                return Enumerable.Empty<ProductViewModel>();

            var productViewModels = CreateProductViewModelsFromProducts(products);

            return productViewModels;
        }

        public async Task<int> CreateProductAsync(CreateProductInputModel inputModel, CancellationToken cancellationToken)
        {
            if (inputModel == null)
                throw new NullReferenceException("Product Id Is Invalid");

            ValidateProductName(inputModel.ProductName);

            ValidateProductTitle(inputModel.ProductTitle);

            var product = CreateProductEntityFromInputModel(inputModel);

            int productId = await _productWriteRepository.CreateProductAsync(product, cancellationToken).ConfigureAwait(false);

            return productId;
        }

        public async Task UpdateProductAsync(UpdateProductInputModel inputModel, CancellationToken cancellationToken)
        {
            if (inputModel.ProductId <= 0)
                throw new NullReferenceException("ProductId Is Invalid.");

            ValidateProductName(inputModel.ProductName);

            ValidateProductTitle(inputModel.ProductTitle);

            await IsExistProduct(inputModel.ProductId, cancellationToken).ConfigureAwait(false);

            var productEntoty = CreateProductEntityFromInputModel(inputModel);

            await _productWriteRepository.UpdateProductAsync(productEntoty, cancellationToken).ConfigureAwait(false);

        }

        public async Task DeleteProductAsync(int productId, CancellationToken cancellationToken)
        {
            if (productId <= 0)
                throw new NullReferenceException("ProductId Is Invalid.");

            await IsExistProduct(productId, cancellationToken).ConfigureAwait(false);

            await _productWriteRepository.DeleteProductAsync(productId, cancellationToken).ConfigureAwait(false);

        }

        #endregion Implement

        #region Private

        private async Task IsExistProduct(int productId, CancellationToken cancellationToken)
        {
            var isExistProduct = await _productReadRepository.IsExistProductAsync(productId, cancellationToken).ConfigureAwait(false);
            if (isExistProduct == false)
                throw new NullReferenceException("ProductId Is Not Found.");
        }

        private Product CreateProductEntityFromInputModel(CreateProductInputModel inputModel)
            => new Product(inputModel.ProductName, inputModel.ProductTitle, inputModel.ProductDescription, inputModel.MainImageName, inputModel.MainImageTitle, inputModel.MainImageUri, inputModel.IsExisting, inputModel.IsFreeDelivery, inputModel.Weight);

        private Product CreateProductEntityFromInputModel(UpdateProductInputModel inputModel)
            => new Product(inputModel.ProductId, inputModel.ProductName, inputModel.ProductTitle, inputModel.ProductDescription, inputModel.MainImageName, inputModel.MainImageTitle, inputModel.MainImageUri, inputModel.IsExisting, inputModel.IsFreeDelivery, inputModel.Weight);

        private ProductViewModel CreateProductViewModelFromProduct(Product product)
            => new ProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductTitle = product.ProductTitle,
                ProductDescription = product.ProductDescription,
                MainImageName = product.MainImageName,
                MainImageTitle = product.MainImageTitle,
                MainImageUri = product.MainImageUri,
                IsExisting = product.IsExisting,
                IsFreeDelivery = product.IsFreeDelivery,
                Weight = product.Weight
            };

        private IEnumerable<ProductViewModel> CreateProductViewModelsFromProducts(IEnumerable<Product> products)
        {
            ICollection<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
                productViewModels.Add(
                     new ProductViewModel()
                     {

                         ProductId = product.ProductId,
                         ProductName = product.ProductName,
                         ProductTitle = product.ProductTitle,
                         ProductDescription = product.ProductDescription,
                         MainImageName = product.MainImageName,
                         MainImageTitle = product.MainImageTitle,
                         MainImageUri = product.MainImageUri,
                         IsExisting = product.IsExisting,
                         IsFreeDelivery = product.IsFreeDelivery,
                         Weight = product.Weight
                     });


            return (IEnumerable<ProductViewModel>)productViewModels;
        }

        private void ValidateProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException(nameof(productName), "Product Name cannot be nul.l");
        }

        private void ValidateProductTitle(string productTitle)
        {
            if (string.IsNullOrEmpty(productTitle) || string.IsNullOrWhiteSpace(productTitle))
                throw new ArgumentException(nameof(productTitle), "Product Title cannot be null.");
        }

        #endregion Private
    }
}
