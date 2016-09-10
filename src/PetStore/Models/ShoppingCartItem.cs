﻿namespace PetStore.Models
{
    public class ShoppingCartItem
    {
        public string ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}