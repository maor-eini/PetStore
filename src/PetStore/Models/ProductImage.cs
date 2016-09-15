namespace PetStore.Models
{
    public class ProductImage
    { 

        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public byte[] Image { get; set; }
    }
}
