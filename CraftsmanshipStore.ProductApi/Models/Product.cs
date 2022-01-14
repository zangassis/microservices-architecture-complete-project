namespace CraftsmanshipStore.ProductApi.Models;

[Table("product")]
public record Product : BaseEntity
{
    [Column("name")]
    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Column("description")]
    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    [Column("price")]
    [Required]
    public decimal Price { get; set; }

    [Column("category_name")]
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }

    [Column("image_url")]
    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; }
}