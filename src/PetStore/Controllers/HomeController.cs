using Microsoft.AspNetCore.Mvc;

namespace PetStore.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

    }
}
