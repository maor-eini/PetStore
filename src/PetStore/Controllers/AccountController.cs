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

        //Display User Details
        public async Task<IActionResult> Details(string id)
        {
            var account = await _userManager.FindByIdAsync(id);

            return View(account);
        }

        //Display Empty User Form
        public IActionResult Create()
        {
            var accountForm = new AccountFormViewModel();
            accountForm.Heading = "Create a new User";
            accountForm.GenderOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "M", Text = "Male"},
                new SelectListItem { Value = "F", Text = "Female" }
            };
            return View("UserForm", accountForm);
        }

        //Display Filled User Form 
        public async Task<IActionResult> Update(string id)
        {

            var account = await _userManager.FindByIdAsync(id);

            if (account == null)
                return NotFound();

            if (User.Identity.Name == account.UserName || User.IsInRole("Admin"))
            {
                var viewModel = new AccountFormViewModel()
                {
                    Id = account.Id,
                    Heading = $"Edit {account.FirstName} {account.LastName}",
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Gender = account.Gender,
                    DateOfBirth = account.DateOfBirth,
                    GenderOptions = new List<SelectListItem>
                        {
                            new SelectListItem { Value = "M", Text = "Male"},
                            new SelectListItem { Value = "F", Text = "Female" }
                        }

                };

                return View("UserForm", viewModel);
            }

            return View("User");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var accountInDb = await _userManager.FindByIdAsync(id.ToString());

            if (accountInDb == null)
                return NotFound();

            await _userManager.DeleteAsync(accountInDb);

            return View();
        }


        #endregion

        #region Http POST actions

        [HttpPost]
        public async Task<IActionResult> Create(AccountFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GenderOptions = new List<SelectListItem>
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
                DateOfBirth = viewModel.DateOfBirth,
            };

            await _userManager.CreateAsync(account);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(AccountFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GenderOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                };
                return View("UserForm", viewModel);
            }

            //Update existing User
            var accountInDb = await _userManager.FindByIdAsync(viewModel.Id.ToString());

            if (accountInDb == null)
                return NotFound();

            accountInDb.FirstName = viewModel.FirstName;
            accountInDb.LastName = viewModel.LastName;
            accountInDb.Gender = viewModel.Gender;
            accountInDb.DateOfBirth = viewModel.DateOfBirth;

            await _userManager.UpdateAsync(accountInDb);

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Helpers




        #endregion
    }

}
