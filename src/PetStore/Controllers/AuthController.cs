using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using PetStore.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IPetRepository _petRepository;
        private readonly IPetTypeRepository _petTypeRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        public AuthController(
            UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IPetRepository petRepository,
            IPetTypeRepository petTypeRepository,
            IUserAddressRepository userAddressRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _petRepository = petRepository;
            _petTypeRepository = petTypeRepository;
            _userAddressRepository = userAddressRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToLocal(returnUrl);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            var registerViewModel = new RegisterViewModel
            {
                UserForm = new AccountFormViewModel { Heading = "Register to Pet Shop" },
                PetForm = new PetFormViewModel
                {
                    TypeOptions = _petTypeRepository.GetAll()
                    .Select(pt => new SelectListItem() { Value = pt.Id.ToString() ,Text = pt.Name })
                }
            };

            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<UserAccount>(model.UserForm);
                user.UserAddress = Mapper.Map<UserAddress>(model.AddressForm);
                user.Pet = Mapper.Map<Pet>(model.PetForm);
                user.DateAdded = DateTime.Now;
                user.LastUpdated = DateTime.Now;

                _petRepository.Add(user.Pet);
                _userAddressRepository.Add(user.UserAddress);

                var result = await _userManager.CreateAsync(user, model.UserForm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
