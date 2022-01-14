namespace CraftsmanshipStore.ProductApi.Configs;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps() =>
        new MapperConfiguration(config => { 
            config.CreateMap<ProductDto, Product>();
            config.CreateMap<Product, ProductDto>();
        });
}