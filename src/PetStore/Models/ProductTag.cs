namespace PetStore.Models
{
    public class ProductTag
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string Tag { get; set; }
    }
}
