using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
