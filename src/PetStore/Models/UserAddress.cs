using System.Collections.Generic;

namespace PetStore.Models
{
    public class UserAddress
    {
        public UserAddress()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }

    }
}
