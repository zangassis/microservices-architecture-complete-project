namespace CraftsmanshipStore.ProductApi.Apis.v1.Interfaces;

public interface IProductApi
{
    IResult Find();
    IResult FindById(Guid id);
    IResult Post(ProductDto productDto);
    IResult Put(Guid id, ProductDto productDto);
    IResult Delete(Guid id);
    void Register(WebApplication app);
}