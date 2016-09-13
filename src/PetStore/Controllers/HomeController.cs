using Microsoft.AspNetCore.Mvc;
using PetStore.Data.UnitOfWork;

namespace PetStore.Controllers
{

    public class HomeController : Controller
    {
        IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var products = _unitOfWork.Products.GetTopSellingProduct(10);
            return View();
        }

    }
}
