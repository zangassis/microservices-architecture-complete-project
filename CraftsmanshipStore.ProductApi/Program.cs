var builder = WebApplication.CreateBuilder(args);

// Register your services
RegisterServices(builder.Services);

// Add services to the container.
var app = builder.Build();

// App configurations
ConfigureApp(app);

app.Run();

void ConfigureApp(WebApplication app)
{
    var ctx = app.Services.CreateScope().ServiceProvider.GetService<MySQLContext>();
    ctx.Database.EnsureCreated();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Configure the Middleware
    var productApis = app.Services.GetServices<IProductApi>();

    foreach (var api in productApis)
    {
        if (api is null)
            ThrowException();
        else
            api.Register(app);
    }

    app.UseAuthorization();

    app.MapControllers();
}

void RegisterServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Product API",
            Description = "Product administration",
            Version = "v1"
        });
    });
    services.AddDbContext<MySQLContext>();
    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    services.AddSingleton(mapper);
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddTransient<IProductRepository, ProductRepository>();
    services.AddTransient<IProductApi, ProductApi>();
}

void ThrowException() =>
    throw new InvalidProgramException("Apis not found");