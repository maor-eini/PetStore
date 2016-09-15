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
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCarts { get; set; }
        public virtual ICollection<OrderItem> Orders { get; set; }
        public virtual ICollection<ProviderItem> Providers { get; set; }

    }
}
