namespace AspNetTailwind.ApplicationCore.Models
{
    public class Product : BaseEntity
    {
        public Product(
            string code,
            string? description,
            string? imageUrl = null)
        {
            Code = code;
            Description = description;
            ImageUrl = imageUrl;
        }

        public string Code { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;
    }
}
