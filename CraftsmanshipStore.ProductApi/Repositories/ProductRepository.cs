namespace CraftsmanshipStore.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MySQLContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> FindAll() 
    {
        var products = await _context.Products.ToListAsync();

        var productsMapper = _mapper.Map<List<ProductDto>>(products);

        return productsMapper.ToList();
    }
        
    public async Task<ProductDto> FindById(Guid id) =>
        _mapper.Map<ProductDto>(await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync());

    public async Task<ProductDto> Create(ProductDto productDto)
    {
        productDto.Id = Guid.NewGuid();

        Product product = _mapper.Map<Product>(productDto);

        _context.Add(product);

        await _context.SaveChangesAsync();

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Update(ProductDto productDto, Guid id)
    {
        var productEntity = _context.Products.Find(id);

        Product product = _mapper.Map<Product>(productDto);

        _context.Entry(productEntity).CurrentValues.SetValues(product);

        await _context.SaveChangesAsync();

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            var productEntity = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (productEntity is null)
                return false;

            _context.Products.Remove(productEntity);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

