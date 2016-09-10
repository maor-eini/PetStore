namespace PetStore.Models
{
    public class ProviderItem
    {
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
