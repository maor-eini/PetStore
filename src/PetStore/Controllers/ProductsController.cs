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
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore.Controllers
{
    [Authorize(Roles = "Admin")]
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
            IProductRepository productRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _providerRepository = providerRepository;
            _productRepository = productRepository;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult List(string category, string sub)
        {
            var products = _productRepository.Find(p => p.Category == category && p.SubCategory == sub);
            return View(products);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            return View(_productRepository.Find(p => p.Id == id).SingleOrDefault());
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            var productForm = new ProductFormViewModel
            {
                Heading = "Add New Product",
            };

            return View(productForm);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Create(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductForm", model);
            }

            var product = Mapper.Map<Product>(model);

            _productRepository.Add(product);

            return RedirectToAction("Index", "Home");
        }


        // GET: /<controller>/Update
        public IActionResult Update(int id)
        {
            var product = _productRepository.GetProductById(id);
            var productFrom = Mapper.Map<ProductFormViewModel>(product);
            return View(productFrom);
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
            _productRepository.Remove(_productRepository.Find(p => p.Id == id).Single());
            return View();
        }
    }
}
