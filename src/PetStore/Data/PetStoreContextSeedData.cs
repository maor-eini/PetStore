using Microsoft.AspNetCore.Identity;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class PetStoreContextSeedData
    {
        private PetStoreContext _context { get; set; }
        public PetStoreContextSeedData(PetStoreContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if (!_context.OrderStatus.Any())
            {
                var statusOptions = new List<OrderStatus>()
                {
                    new OrderStatus { Name = "New" },
                    new OrderStatus { Name = "Hold" },
                    new OrderStatus { Name = "Shipped" },
                    new OrderStatus { Name = "Delivered" },
                    new OrderStatus { Name = "Closed" },
                };

                statusOptions.AddRange(statusOptions);
            }

            if (!_context.PetTypes.Any())
            {
                var petTypes = new List<PetType>()
                {
                    new PetType { Id = 1, Name = "Dog" },
                    new PetType { Id = 2, Name = "Cat" },
                    new PetType { Id = 3, Name = "Fish" },
                    new PetType { Id = 4, Name = "Rabbit" }
                };

                _context.PetTypes.AddRange(petTypes);
            }

            if (!_context.Users.Any())
            {
                var user = new UserAccount
                {
                    FirstName = "Example",
                    LastName = "Dude",
                    Gender = "M",
                    DateOfBirth = new DateTime(1989, 11, 24),
                    DateAdded = DateTime.Now,
                    Email = "maor.eini@gmail.com",
                    PhoneNumber = "0505335313",
                    UserName = "maor.eini@gmail.com",
                    Orders = new List<Order>()
                    {
                        new Order { OrderedDate = DateTime.Now, ShippedDate = DateTime.Now, StatusId = 1,  }
                    }
                };

                user.PasswordHash = new PasswordHasher<UserAccount>().HashPassword(user, "Maor123#@!");
            }
        }
    }
}
