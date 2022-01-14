namespace CraftsmanshipStore.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string BasePath = "/v1/products";

    public ProductService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        var response = await _client.GetAsync(BasePath);

        return await response.ReadContentAsync<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(Guid id)
    {
        var response = await _client.GetAsync($"{BasePath}/{id}");

        return await response.ReadContentAsync<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel model)
    {
        var response = await _client.PostAsJson(BasePath, model);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAsync<ProductModel>();
        else
            throw new Exception("Something went wrong when create the product");
    }

    public async Task<ProductModel> UpdateProduct(ProductModel model)
    {
        var response = await _client.PutAsJson($"{BasePath}/{model.Id}", model);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAsync<ProductModel>();
        else
            throw new Exception("Something went wrong when update the product");
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var response = await _client.DeleteAsync($"{BasePath}/{id}");

        if (response.IsSuccessStatusCode)
            return true;
        else
            throw new Exception("Something went wrong when create the product");
    }
}