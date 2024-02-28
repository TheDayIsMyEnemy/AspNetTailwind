namespace AspNetTailwind.ApplicationCore.Models
{
    public class Category : BaseEntity
    {
        public Category(
            string name,
            string? imageUrl = null)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public string Name { get; private set; }
        public string? ImageUrl { get; private set; }

        public ICollection<Product> Products { get; set; } = null!;
    }
}
