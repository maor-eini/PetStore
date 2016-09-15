using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PetStore.Models;
using PetStore.Data.Repositories.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductsController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IProviderRepository _providerRepository;
        private readonly IProductRepository _productRepository;
        public ProductsController(
            UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IProviderRepository providerRepository,
            IProductRepository productRepository,
            IUserAddressRepository userAddressRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _providerRepository = providerRepository;
            _productRepository = productRepository;
        }
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult List()
        {
            return View(_productRepository.GetAll());
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            return View(_productRepository.Get(id));
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            var productForm = new ProductFormViewModel();
            return View(productForm);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Create(ProductFormViewModel viewModel)
        {
            
            return View();
        }


        // GET: /<controller>/Update
        public IActionResult Update(int id)
        {
            return View();
        }


        // GET: /<controller>/
        [HttpPost]
        public IActionResult Update(ProductFormViewModel viewModel)
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
