using System.Collections.Generic;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            ShoppingCarts = new HashSet<ShoppingCartItem>();
            Orders = new HashSet<OrderItem>();
            Providers = new HashSet<ProviderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductImage Image { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCarts { get; set; }
        public virtual ICollection<OrderItem> Orders { get; set; }
        public virtual ICollection<ProviderItem> Providers { get; set; }

    }
}
