using Microsoft.AspNetCore.Mvc;

namespace COMB.SpaParking.MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Development()
        {
            return View();
        }

        [HttpGet("/Error/404")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [HttpGet("/Error/400")]
        public IActionResult Badrequest()
        {
            return View();
        }
    }
}
