using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PetStore.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using PetStore.Data.Repositories.Interfaces;
using AutoMapper;

namespace PetStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IPetRepository _petRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        public AccountController(
            UserManager<UserAccount> userManager, 
            SignInManager<UserAccount> signInManager,
            IPetRepository petRepository,
            IUserAddressRepository userAddressRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _petRepository = petRepository;
            _userAddressRepository = userAddressRepository;
        }

        #region Http GET actions

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
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
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            var userAccountViewModel = new AccountFormViewModel
            {
                
                GenderOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                }
            }
            ;

            return View(userAccountViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var user = Mapper.Map<UserAccount>(model.UserForm);

                user.UserAddresses = new List<UserAddress>()
                {
                    Mapper.Map<UserAddress>(model.AddressForm)
                };

                user.Pets = new List<Pet>()
                {
                    Mapper.Map<Pet>(model.PetForm)
                };

                _petRepository.AddRange(user.Pets);
                _userAddressRepository.AddRange(user.UserAddresses);

                var result = await _userManager.CreateAsync(user, model.UserForm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //Display User Details
        public async Task<IActionResult> Details(string id)
        {
            var account = await _userManager.FindByIdAsync(id);

            return View(account);
        }

        //Display Empty User Form
        public IActionResult Create()
        {
            var userForm = new UserFormViewModel();
            userForm.Heading = "Create a new User";
            userForm.GenderList = new List<SelectListItem>
            {
                new SelectListItem { Value = "M", Text = "Male"},
                new SelectListItem { Value = "F", Text = "Female" }
            };
            return View("UserForm", userForm);
        }

        //Display Filled User Form 
        public async Task<IActionResult> Update(string id)
        {

            var account = await _userManager.FindByIdAsync(id);

            if (account == null)
                return NotFound();

            if (User.Identity.Name == account.UserName || User.IsInRole("Admin"))
            {
                var viewModel = new UserFormViewModel()
                {
                    Id = account.Id,
                    Heading = $"Edit {account.FirstName} {account.LastName}",
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Gender = account.Gender,
                    DateOfBirth = account.DateOfBirth.ToString("d MMM yyyy"),
                    GenderList = new List<SelectListItem>
                        {
                            new SelectListItem { Value = "M", Text = "Male"},
                            new SelectListItem { Value = "F", Text = "Female" }
                        }

                };

                return View("UserForm", viewModel);
            }


            return View("User");

        }


        #endregion

        #region Http POST actions

        [HttpPost]
        public async Task<IActionResult> Create(UserFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GenderList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                };
                return View("UserForm", viewModel);
            }

            //Create new user
            var account = new UserAccount
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Gender = viewModel.Gender,
                DateOfBirth = viewModel.GetDateTimeOfBirth(),
            };

            await _userManager.CreateAsync(account);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GenderList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                };
                return View("UserForm", viewModel);
            }

            //Update existing User
            var userInDb = await _userManager.FindByIdAsync(viewModel.Id.ToString());

            if (userInDb == null)
                return NotFound();

            userInDb.FirstName = viewModel.FirstName;
            userInDb.LastName = viewModel.LastName;
            userInDb.Gender = viewModel.Gender;
            userInDb.DateOfBirth = viewModel.GetDateTimeOfBirth();

            await _userManager.UpdateAsync(userInDb);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userInDb = await _userManager.FindByIdAsync(id.ToString());

            if (userInDb == null)
                return NotFound();

            await _userManager.DeleteAsync(userInDb);

            return View();
        }

        #endregion

        #region Helpers


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }

}
