//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using PetStore.Models;
//using PetStore.Data.Repositories.Interfaces;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc.Rendering;

//For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace PetStore.Controllers
//{
//    [Authorize]
//    public class ShoppingCartController : Controller
//    {
//        private readonly UserManager<UserAccount> _userManager;
//        private readonly IShoppingCartRepository _shoppingCartRepository;
//        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

//        public ShoppingCartController(UserManager<UserAccount> userManager,
//            IShoppingCartRepository shoppingCartRepository,
//            IShoppingCartItemRepository shoppingCartItemRepository)
//        {
//            _userManager = userManager;
//            _shoppingCartRepository = shoppingCartRepository;
//            _shoppingCartItemRepository = shoppingCartItemRepository;
//        }
//        GET: /<controller>/
//        public async Task<IActionResult> Index()
//        {
//            var user = await _userManager.GetUserAsync(User);
//            var cart = _shoppingCartRepository.GetShoppingCartByUserId(user.Id);
//            cart.

//            if (!HasPermission("VIEW_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            var customers = await _context.Customers.ToListAsync();

//            return View(customers.ToListViewModel());
//        }

//        public async Task<IActionResult> Statement(int? id)
//        {
//            if (!HasPermission("VIEW_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            if (id == null)
//            {
//                return NotFound();
//            }

//            Customer customer = await _context.Customers.SingleAsync(m => m.Id == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            var bookings = await _context.Bookings
//                .Include(b => b.Origin)
//                .Include(b => b.Destination)
//                .Include(b => b.Customer)
//                .Include(b => b.Package)
//                .Include(b => b.Package.PackageType)
//                .Include(b => b.Invoice)
//                .Include(b => b.CreatedBy)
//                .Include(b => b.Service)
//                .Where(b => b.Invoice.Status != InvoiceStatus.Paid /*&& b.Invoice.BillingMode == BillingMode.BillToAccount*/)
//                .ToListAsync();

//            ViewData["Customer"] = customer.ToDetailsViewModel();

//            return View(bookings.ToListViewModel());
//        }

//        public async Task<IActionResult> Details(int? id)
//        {
//            if (!HasPermission("VIEW_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            if (id == null)
//            {
//                return NotFound();
//            }

//            Customer customer = await _context.Customers.SingleAsync(m => m.Id == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer.ToDetailsViewModel());
//        }

//        public IActionResult Create()
//        {
//            if (!HasPermission("CREATE_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(CustomerViewModel model)
//        {
//            if (!HasPermission("CREATE_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            if (ModelState.IsValid)
//            {
//                _context.Customers.Add(model.ToEntity());
//                await _context.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (!HasPermission("EDIT_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.Customers.SingleAsync(m => m.Id == id);

//            if (customer == null)
//            {
//                return NotFound();
//            }
//            return View(customer.ToViewModel());
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(CustomerViewModel model)
//        {
//            if (!HasPermission("EDIT_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            var customer = await _context.Customers.SingleAsync(m => m.Id == model.Id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                customer = model.UpdateEntity(customer);

//                _context.Update(customer);

//                await _context.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        [ActionName("Delete")]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (!HasPermission("DELETE_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            if (id == null)
//            {
//                return NotFound();
//            }

//            Customer customer = await _context.Customers.SingleAsync(m => m.Id == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer.ToDetailsViewModel());
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (!HasPermission("DELETE_CUSTOMERS"))
//            {
//                return Unauthorized();
//            }

//            Customer customer = await _context.Customers.SingleAsync(m => m.Id == id);
//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }
//    }




//}
