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
        public StatusCodeResult Post(int id)
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
                        UserAccount = user
                    };

                    _unitOfWork.ShoppingCarts.Add(cart);
                    _unitOfWork.Complete();
                }

                var requestedProduct = _unitOfWork.Products.Find(t => t.Id == id).SingleOrDefault();

                if (requestedProduct==null)
                {
                    return BadRequest();
                }

                var cartItem = _unitOfWork.ShoppingCartItems.Find(t=>t.ProductId == id).SingleOrDefault();

                if (cartItem == null)
                {
                    cartItem = new ShoppingCartItem
                    {
                        Product = requestedProduct,
                        Quantity = 1,
                        ShoppingCart = cart,
                    };

                    _unitOfWork.ShoppingCartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity += 1;
                }

                _unitOfWork.Complete();

                return Ok();

            }

            return BadRequest();
        }

        // PUT api/ShoppingCartItem/5/1
        [HttpPut("{id}/{count}")]
        public StatusCodeResult Put(int id, int count)
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

                var requestedProduct = _unitOfWork.Products.Find(t => t.Id == id).SingleOrDefault();

                if (requestedProduct == null)
                {
                    return BadRequest();
                }

                var cartItem = _unitOfWork.ShoppingCartItems.Find(t => t.ProductId == id).SingleOrDefault();

                if (cartItem == null)
                {
                    cartItem = new ShoppingCartItem
                    {
                        Product = requestedProduct,
                        Quantity = 1,
                        ShoppingCart = cart,
                    };
                }
                else
                {
                    cartItem.Quantity += 1;
                }


                cart.ShoppingCartItems = new List<ShoppingCartItem> { cartItem };
                _unitOfWork.ShoppingCartItems.Add(cartItem);
                _unitOfWork.Complete();

                return Ok();

            }

            return BadRequest();
        }

        // DELETE api/ShoppingCartItem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
