namespace PetStore.Models
{
    public class ProviderItem
    {
        public string ProviderId { get; set; }
        public Provider Provider { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
