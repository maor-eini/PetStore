using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }

        public string UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
