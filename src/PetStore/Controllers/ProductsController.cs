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
using PetStore.Data.UnitOfWork;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(
            UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult List(string category, string sub)
        {
            var products = _unitOfWork.Products.Find(p => p.Category == category && p.SubCategory == sub);
            return View(products);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            return View(_unitOfWork.Products.Find(p => p.Id == id).Single());
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
                return View("Create", model);
            }

            var product = Mapper.Map<Product>(model);

            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }


        // GET: /<controller>/Update
        public IActionResult Update(int id)
        {
            var product = _unitOfWork.Products.GetProductById(id);
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
            _unitOfWork.Products.Remove(_unitOfWork.Products.Find(p => p.Id == id).Single());
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Home");
        }
    }
}
