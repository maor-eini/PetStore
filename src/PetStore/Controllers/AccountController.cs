using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PetStore.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace PetStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserAccount> _userManger;
        public AccountController(UserManager<UserAccount> userManger)
        {
            _userManger = userManger;
        }

        #region Http GET actions

        //Display User List
        public IActionResult Index()
        {
            return View();
        }

        //Display User Details
        public async Task<IActionResult> Details(string username)
        {
            var account = await _userManger.FindByNameAsync(username);

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
        public async Task<IActionResult> Update(string username)
        {
            var account = await _userManger.FindByNameAsync(username);

            if (account == null)
                return NotFound();

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

            await _userManger.CreateAsync(account);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
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
            var userInDb = await _userManger.FindByNameAsync(viewModel.Id.ToString());

            if (userInDb == null)
                return NotFound();

            userInDb.FirstName = viewModel.FirstName;
            userInDb.LastName = viewModel.LastName;
            userInDb.Gender = viewModel.Gender;
            userInDb.DateOfBirth = viewModel.GetDateTimeOfBirth();

            await _userManger.UpdateAsync(userInDb);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userInDb = await _userManger.FindByIdAsync(id.ToString());

            if (userInDb == null)
                return NotFound();

            await _userManger.DeleteAsync(userInDb);

            return View();
        }

        #endregion
    }

}
