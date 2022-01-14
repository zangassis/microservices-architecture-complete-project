namespace CraftsmanshipStore.ProductApi.Apis.v1;

public class ProductApi : IProductApi
{
    IProductRepository service;

    public void Register(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        service = scope.ServiceProvider.GetService<IProductRepository>();

        app.MapGet("/v1/products", Find);
        app.MapGet("/v1/products/{id}", FindById);
        app.MapPost("/v1/products", Post).Produces<ProductDto>(StatusCodes.Status201Created);
        app.MapPut("/v1/products/{id}", Put).Produces(StatusCodes.Status404NotFound).Produces(StatusCodes.Status204NoContent);
        app.MapDelete("v1/products/{id}", Delete).Produces(StatusCodes.Status204NoContent);
    }

    public IResult Find() =>
        Results.Ok(service.FindAll().Result);

    public IResult FindById(Guid id)
    {
        var product = service.FindById(id).Result;

        if (product is null)
            return Results.NotFound();

        return Results.Ok(product);
    }

    public IResult Post(ProductDto productDto)
    {
        try
        {
            var product = service.Create(productDto).Result;

            return Results.Created($"/contact/{product.Id}", product);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex);
        }
    }

    public IResult Put(Guid id, ProductDto productDto)
    {
        try
        {
            var product = service.FindById(id).Result;

            if (product is null)
                return Results.NotFound();

            var updatedProduct = service.Update(productDto, id).Result;

            return Results.Ok(updatedProduct);
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Error ocurred while puting to Product: {ex.Message}");
        }
    }

    public IResult Delete(Guid id)
    {
        var success = service.Delete(id).Result;

        if (success == false)
            return Results.NotFound();

        return Results.NoContent();
    }
}