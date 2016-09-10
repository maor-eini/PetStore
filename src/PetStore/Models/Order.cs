using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string UserAccountId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShippingAddressId { get; set; }
        public UserAddress ShippingAddress { get; set; }
        public string StatusId { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Products { get; set; }
    }
}
