using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShippingAddressId { get; set; }
        public UserAddress ShippingAddress { get; set; }
        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Products { get; set; }
    }
}
