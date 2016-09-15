using System.Collections.Generic;

namespace PetStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int CategoryId { get; set; }

        public ProductCategory Category { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCarts { get; set; }
        public ICollection<OrderItem> Orders { get; set; }
        public ICollection<ProviderItem> Providers { get; set; }

    }
}
