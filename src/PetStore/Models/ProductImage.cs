namespace PetStore.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public byte[] Image { get; set; }
    }
}
