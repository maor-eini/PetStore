using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PetStore.Models;
using PetStore.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using PetStore.ViewModels.ShoppingCart;

namespace PetStore.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(UserManager<UserAccount> userManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(user.Id);

            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            return View();
        }

        [HttpPost]
        [Route("api/ShoppingCart/{id}")]
        public StatusCodeResult Create(int productId)
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


        public async Task<IActionResult> Details(int? id)
        {
            
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoppingCartViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }




}
