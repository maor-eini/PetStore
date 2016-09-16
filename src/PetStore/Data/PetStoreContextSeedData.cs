using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class PetStoreContextSeedData
    {
        private RoleManager<UserRole> _roleManager;
        private PetStoreContext _context { get; set; }
        private UserManager<UserAccount> _userManager { get; set; }
        public PetStoreContextSeedData(PetStoreContext context, UserManager<UserAccount> userManager, RoleManager<UserRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            if (!_context.OrderStatus.Any())
            {
                var statusOptions = new[]
                {
                    new OrderStatus { Name = "New",},
                    new OrderStatus { Name = "Hold" },
                    new OrderStatus { Name = "Shipped" },
                    new OrderStatus { Name = "Delivered" },
                    new OrderStatus { Name = "Closed" },
                };

                _context.OrderStatus.AddRange(statusOptions);
                await _context.SaveChangesAsync();
            }

            if (!_context.PetTypes.Any())
            {
                var petTypes = new[]
                {
                    new PetType { Name = "Dog" },
                    new PetType { Name = "Cat" },
                    new PetType { Name = "Fish" },
                    new PetType { Name = "Rabbit" }
                };

                _context.PetTypes.AddRange(petTypes);
                await _context.SaveChangesAsync();
            }

            if (!_context.Users.Any() && !_context.Roles.Any())
            {
                var userAdmin = new UserAccount
                {
                    FirstName = "Maor",
                    LastName = "Eini",
                    Gender = "M",
                    DateOfBirth = new DateTime(1989, 11, 24),
                    DateAdded = DateTime.Now,
                    Email = "maor.eini@gmail.com",
                    PhoneNumber = "0505335313",
                    UserName = "maor.eini@gmail.com",
                    UserAddress = new UserAddress { City = "Rishon Le Zion", BuildingNumber = "5 ", ApartmentNumber = "18", Province = "HaMerkaz", Street = "Kapah", State = "Israel", ZipCode = "7573006" },
                    Orders = new HashSet<Order>(),
                    Pet = new Pet
                    {
                        Name = "Lucas",
                        Size = "S",
                        Type = _context.PetTypes.Where(p => p.Name == "Dog").SingleOrDefault()
                    }
                };

                var userOrder = new Order
                {
                    OrderedDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    Status = _context.OrderStatus.Where(os => os.Name == "New").SingleOrDefault(),
                    TotalPrice = 10,
                    Products = new HashSet<OrderItem>(),
                    ShippingAddress = userAdmin.UserAddress
                };


                var ProductOne = new Product
                {
                    Manufacturer = "Nature's Variety",
                    Price = 5,
                    Name = "Instinct for small dogs",
                    ProductCode = "54CD7",
                    Description = "Instinct 5kg for small dogs. Duck.",
                    Category = "Dog",
                    SubCategory="Food"
                };

                var ProductTwo = new Product
                {
                    Manufacturer = "Nature's Variety",
                    Price = 5,
                    Name = "Instinct for large dogs",
                    ProductCode = "54CD8",
                    Description = "Instinct 12kg for large dogs. Duck.",
                    Category = "Dog",
                    SubCategory="Bowls"
                };

                var orderItemOne = new OrderItem
                {
                    Order = userOrder,
                    Product = ProductOne
                };

                var orderItemTwo = new OrderItem
                {
                    Order = userOrder,
                    Product = ProductTwo
                };

                userOrder.Products.Add(orderItemOne);
                userOrder.Products.Add(orderItemTwo);

                userAdmin.Orders.Add(userOrder);
                userAdmin.PasswordHash = new PasswordHasher<UserAccount>().HashPassword(userAdmin, "Maor123#@!");

                var userResult = await _userManager.CreateAsync(userAdmin);

                if (userResult.Succeeded)
                {
                    var adminRole = new UserRole { Name = "Admin" };
                    var adminResult = await _roleManager.CreateAsync(adminRole);

                    if (adminResult.Succeeded)
                    {
                        var result = await _userManager.AddToRoleAsync(userAdmin, adminRole.Name);
                        if (result.Succeeded)
                        {
                            await _context.SaveChangesAsync();
                        }
                    }
                }

            }



        }
    }
}

