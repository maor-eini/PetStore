using System.Collections.Generic;

namespace PetStore.Models
{

    public class OrderStatus
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

    //public enum OrderStatus
    //{
    //    New,
    //    Hold,
    //    Shipped,
    //    Delivered,
    //    Closed
    //}
}
