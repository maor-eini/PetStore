namespace PetStore.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
