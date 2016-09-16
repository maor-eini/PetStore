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

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var cart = _unitOfWork.ShoppingCarts.GetShoppingCartByUserId(user.Id);

            return View(cart ?? new ShoppingCart());
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

    }




}
