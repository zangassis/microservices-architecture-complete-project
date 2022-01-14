namespace CraftsmanshipStore.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> FindAllProducts();
    Task<ProductModel> FindProductById(Guid id);
    Task<ProductModel> CreateProduct(ProductModel model);
    Task<ProductModel> UpdateProduct(ProductModel model);
    Task<bool> DeleteProduct(Guid id);
}