using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class UserAccount : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PasswordOld { get; set; }
        public string IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }

        public ICollection<Pet> Pets { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int UserAddressesId { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }

        public int ImageId { get; set; }
        public UserImage Image { get; set; }


    }
}
