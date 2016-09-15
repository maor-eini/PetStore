using System.Collections.Generic;

namespace PetStore.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
            SubCategories = new HashSet<ProductSubCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductSubCategory> SubCategories { get; set; }

    }
}