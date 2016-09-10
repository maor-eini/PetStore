using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetStore.Models;
using PetStore.ViewModels;
using System.Threading.Tasks;

namespace PetStore.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<UserAccount> _signInManager;
        public AuthController(SignInManager<UserAccount> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager
                    .PasswordSignInAsync(vm.Username, vm.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                }


            }

            return View();
        }
    }
}
