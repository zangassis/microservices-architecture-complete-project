namespace CraftsmanshipStore.ProductApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> FindAll();
    Task<ProductDto> FindById(Guid id);
    Task<ProductDto> Create(ProductDto product);
    Task<ProductDto> Update(ProductDto product, Guid id);
    Task<bool> Delete(Guid id);
}