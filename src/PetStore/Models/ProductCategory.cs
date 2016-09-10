﻿namespace PetStore.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? SubCategoryId { get; set; }
        public ProductCategory SubCategory { get; set; }
    }
}
