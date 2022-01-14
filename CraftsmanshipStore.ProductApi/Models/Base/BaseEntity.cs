namespace CraftsmanshipStore.ProductApi.Models.Base;

public record BaseEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}
