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

            if (!_context.ProductCategories.Any() && !_context.ProductSubCategories.Any() && !_context.Users.Any() && !_context.Roles.Any())
            {

                var productCategory = new[]
                {
                    new ProductCategory {  Name = "Dogs" },
                    new ProductCategory {  Name = "Cats" }
                };

                _context.ProductCategories.AddRange(productCategory);
                await _context.SaveChangesAsync();

                var dogFood = new[]
                {
                    new ProductSubCategory { Name = "Food" , Value = "Dog Food" },
                    new ProductSubCategory { Name = "Food" , Value = "Bowls, Feeders & Wateters" }
                };

                var catFood = new[]
                {
                    new ProductSubCategory { Name = "Food" , Value = "Cat Food" },
                    new ProductSubCategory { Name = "Food" , Value = "Bowls, Feeders & Wateters" }
                };

                productCategory[0].SubCategories = dogFood;
                productCategory[1].SubCategories = catFood;

                _context.ProductSubCategories.AddRange(catFood);
                _context.ProductSubCategories.AddRange(dogFood);
                await _context.SaveChangesAsync();

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

                userAdmin.Pet.UserAccount = userAdmin;

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
                    Category = _context.ProductCategories.Where(c => c.Name == "Dogs").SingleOrDefault()
                };

                var ProductTwo = new Product
                {
                    Manufacturer = "Nature's Variety",
                    Price = 5,
                    Name = "Instinct for large dogs",
                    ProductCode = "54CD8",
                    Description = "Instinct 12kg for large dogs. Duck.",
                    Category = _context.ProductCategories.Where(c => c.Name == "Dogs").SingleOrDefault()
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



        #region Create User
        //if (!_context.Users.Any())
        //{
        //    var user = new UserAccount
        //    {
        //        FirstName = "Example",
        //        LastName = "Dude",
        //        Gender = "M",
        //        DateOfBirth = new DateTime(1989, 11, 24),
        //        DateAdded = DateTime.Now,
        //        Email = "maor.eini@gmail.com",
        //        PhoneNumber = "0505335313",
        //        UserName = "maor.eini@gmail.com",
        //        UserAddress = new UserAddress { City = "Rishon Le Zion", BuildingNumber = "5 ", ApartmentNumber = "18", Province = "HaMerkaz", Street = "Kapah", State = "Israel", ZipCode = "7573006" },
        //        Orders = new List<Order>(),
        //        Pet = new Pet
        //        {
        //            Name = "Lucas",
        //            Size = "S",
        //            Type = new PetType { Name = "Dog" }
        //        }

        //    };

        //    user.Pet.UserAccount = user;

        //    var userOrder = new Order
        //    {
        //        OrderedDate = DateTime.Now,
        //        ShippedDate = DateTime.Now,
        //        Status = new OrderStatus { Name = "New" },
        //        TotalPrice = 10,
        //        Products = new List<OrderItem>(),
        //        ShippingAddress = user.UserAddress
        //    };

        //    var ProductOne = new Product
        //    {
        //        Manufacturer = "Nature's Variety",
        //        Price = 5,
        //        Name = "Instinct for small dogs",
        //        ProductCode = "54CD7",
        //        Description = "Instinct 5kg for small dogs. Duck.",
        //        CategoryId = 1,
        //    };

        //    var ProductTwo = new Product
        //    {
        //        Manufacturer = "Nature's Variety",
        //        Price = 5,
        //        Name = "Instinct for large dogs",
        //        ProductCode = "54CD8",
        //        Description = "Instinct 12kg for large dogs. Duck.",
        //        CategoryId = 1
        //    };

        //    var orderItemOne = new OrderItem
        //    {
        //        Order = userOrder,
        //        Product = ProductOne
        //    };

        //    var orderItemTwo = new OrderItem
        //    {
        //        Order = userOrder,
        //        Product = ProductTwo
        //    };

        //    userOrder.Products.Add(orderItemOne);
        //    userOrder.Products.Add(orderItemTwo);

        //    user.Orders.Add(userOrder);
        //    user.PasswordHash = new PasswordHasher<UserAccount>().HashPassword(user, "Maor123#@!");

        //_userManager.CreateAsync(user).Wait();
        //}

        //Create a Customer
        //var moshePet = new Pet
        //{
        //    Name = "Shnitzel",
        //    Size = "L",
        //    Type = _context.PetTypes.Where(p => p.Name == "Dog").SingleOrDefault(),
        //};

        //var userCustomer = new UserAccount
        //{
        //    FirstName = "Moshe",
        //    LastName = "Haim",
        //    Gender = "M",
        //    DateOfBirth = new DateTime(1970, 11, 24),
        //    DateAdded = DateTime.Now,
        //    Email = "moshe.haim@gmail.com",
        //    PhoneNumber = "0505445414",
        //    UserName = "moshe.haim@gmail.com",
        //    UserAddress = new UserAddress { City = "Rishon Le Zion", BuildingNumber = "5 ", ApartmentNumber = "18", Province = "HaMerkaz", Street = "Kapah", State = "Israel", ZipCode = "7573006" },
        //    Pet = new Pet
        //    {
        //        Name = "Shnitzel",
        //        Size = "L",
        //        Type = _context.PetTypes.Where(p => p.Name == "Dog").SingleOrDefault(),
        //    }

        //};

        //var addMoshe = await _userManager.CreateAsync(userCustomer);

        //if (addMoshe.Succeeded)
        //{
        //    var customerRole = new UserRole { Name = "Customer" };
        //    var customerResult = await _roleManager.CreateAsync(customerRole);

        //    if (customerResult.Succeeded)
        //    {
        //        var result = await _userManager.AddToRoleAsync(userCustomer, customerRole.Name);
        //        if (result.Succeeded)
        //        {
        //            await _context.SaveChangesAsync();
        //        }

        //    }
        //}
        #endregion
    }
}

