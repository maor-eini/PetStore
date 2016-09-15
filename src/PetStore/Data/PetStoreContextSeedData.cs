using Microsoft.AspNetCore.Identity;
using PetStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class PetStoreContextSeedData
    {
        private PetStoreContext _context { get; set; }
        private UserManager<UserAccount> _userManager { get; set; }
        public PetStoreContextSeedData(PetStoreContext context, UserManager<UserAccount> userAccount)
        {
            _context = context;
            _userManager = userAccount;
        }

        public async Task SeedData()
        {
            if (!_context.OrderStatus.Any())
            {
                var statusOptions = new List<OrderStatus>()
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
                var petTypes = new List<PetType>()
                {
                    new PetType { Name = "Dog" },
                    new PetType { Name = "Cat" },
                    new PetType { Name = "Fish" },
                    new PetType { Name = "Rabbit" }
                };

                _context.PetTypes.AddRange(petTypes);
                await _context.SaveChangesAsync();
            }

            if (!_context.ProductCategories.Any() && !_context.ProductSubCategories.Any())
            {
                var foodWeights = new List<ProductSubCategory>
                {
                    new ProductSubCategory { Name = "Weight" , Value = "5kg"},
                    new ProductSubCategory { Name = "Weight" , Value = "12kg" },
                };

                var bedSizes = new List<ProductSubCategory>
                {
                    new ProductSubCategory { Name = "Size" , Value = "XS"},
                    new ProductSubCategory { Name = "Size" , Value = "S" },
                    new ProductSubCategory { Name = "Size" , Value = "M"},
                    new ProductSubCategory { Name = "Size" , Value = "L" },
                    new ProductSubCategory { Name = "Size" , Value = "XL" },
                };

                var toySizes = new List<ProductSubCategory>
                {
                    new ProductSubCategory {  Name = "Size" , Value = "XS"},
                    new ProductSubCategory {  Name = "Size" , Value = "S"},
                    new ProductSubCategory {  Name = "Size" , Value = "M"},
                    new ProductSubCategory {  Name = "Size" , Value = "L"},
                    new ProductSubCategory {  Name = "Size" , Value = "XL"},
                };

                var treatsTaste = new List<ProductSubCategory>
                {
                    new ProductSubCategory { Name = "Taste" , Value = "Duck" },
                    new ProductSubCategory { Name = "Taste" , Value = "Chicken" }
                };

                var productCategory = new List<ProductCategory>
                {
                    new ProductCategory {  Name = "Food" , SubCategories = foodWeights},
                    new ProductCategory {  Name = "Toys" , SubCategories =  toySizes},
                    new ProductCategory {  Name = "Beds" , SubCategories =  bedSizes},
                    new ProductCategory {  Name = "Treats" , SubCategories = treatsTaste}
                };

                _context.ProductCategories.AddRange(productCategory);
                await _context.SaveChangesAsync();

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
            #endregion
        }
    }
}
