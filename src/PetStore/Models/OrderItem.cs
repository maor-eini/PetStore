namespace PetStore.Models
{
    public class OrderItem
    {
        public string OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

    }
}
