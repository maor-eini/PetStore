namespace PetStore.Models
{
    public class ProviderItem
    {
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
