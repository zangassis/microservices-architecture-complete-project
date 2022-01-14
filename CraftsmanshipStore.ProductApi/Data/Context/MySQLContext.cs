namespace CraftsmanshipStore.ProductApi.Data.Context;

public class MySQLContext : DbContext
{
    protected MySQLContext() {}

    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

    public DbSet<Product> Products { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = @"Server=localhost;DataBase=craftsmanship_store_product;Uid=root;Pwd=0v0AWkBn";

        optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(8,0,5)));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Mountain Wood Wall Art",
            Description = "Mountain Wood Wall Art, Painting Wood Wall Art, Vertical Wall Art, Wall Decor, Wood Wall Hanging, Housewarming Gift, Office Decor",
            Price = new decimal(69.8),
            CategoryName = "Painting",
            ImageUrl = "https://images.unsplash.com/photo-1640946756511-f5026d7614f9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Metal Wire Decorative",
            Description = "Glass Tube Vase/Flower Vase Pot/Unique Handmade Home Decor/Living Room Office Table Vase",
            Price = new decimal(147.85d),
            CategoryName = "Flower",
            ImageUrl = "https://images.unsplash.com/photo-1444930694458-01babf71870c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=963&q=80"
        });
    }
}

