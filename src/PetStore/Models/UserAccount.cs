using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class UserAccount : IdentityUser<int>
    {
        public UserAccount() : base()
        {
            Orders = new HashSet<Order>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PasswordOld { get; set; }
        public string IsActive { get; set; }
        public int UserAddressId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual UserAddress UserAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
