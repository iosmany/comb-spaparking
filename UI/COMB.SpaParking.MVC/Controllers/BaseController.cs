using Microsoft.AspNetCore.Mvc;

namespace COMB.SpaParking.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
        }

        public IActionResult BadRequestResult()
            => RedirectToAction("400", "Error");

        public IActionResult NotFoundResult()
           => RedirectToAction("404", "Error");
    }
}
