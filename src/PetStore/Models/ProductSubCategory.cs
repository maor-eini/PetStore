namespace PetStore.Models
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public int MainCategoryId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }


        public ProductCategory MainCategory { get; set; }

    }
}