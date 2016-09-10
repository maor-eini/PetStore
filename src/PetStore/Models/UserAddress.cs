using System.Collections.Generic;

namespace PetStore.Models
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string IsDefaultBillingAddress { get; set; }
        public string IsDefaultShippingAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

    }
}
