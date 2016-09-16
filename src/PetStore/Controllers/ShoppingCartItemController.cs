using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PetStore.Data.UnitOfWork;
using PetStore.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartItemController : Controller
    {

        private readonly UserManager<UserAccount> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartItemController(UserManager<UserAccount> userManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ShoppingCartItem
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/ShoppingCartItem/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ShoppingCartItem
        [HttpPost("{id}")]
        public StatusCodeResult Post(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.GetUserAsync(User).Result;
                var cart = _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(user.Id);
                if (cart == null)
                {
                    cart = new ShoppingCart
                    {
                        DateCreated = DateTime.Now,
                        UserAccount = user,
                    };

                    _unitOfWork.ShoppingCarts.Add(cart);
                    _unitOfWork.Complete();
                }
                var newItem = new ShoppingCartItem
                {
                    Product = _unitOfWork.Products.Get(productId),
                    Quantity = 1,
                    ShoppingCart = cart,
                };

                cart.ShoppingCartItems = new[] { newItem };
                _unitOfWork.ShoppingCartItems.Add(newItem);
                _unitOfWork.Complete();

                return Ok();

            }

            return BadRequest();
        }

        // PUT api/ShoppingCartItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ShoppingCartItem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
