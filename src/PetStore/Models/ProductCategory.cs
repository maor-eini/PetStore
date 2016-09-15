using System.Collections.Generic;

namespace PetStore.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ProductSubCategory> SubCategories { get; set; }

    }
}