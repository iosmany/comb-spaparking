using COMB.SpaParking.Application.ParkingPermits;
using COMB.SpaParking.MVC.Infrastructure;
using COMB.SpaParking.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace COMB.SpaParking.MVC.Controllers
{
    [Authorize(Roles = Roles.CustomerServiceRep)]
    public class ParkingPermitController : BaseController
    {
        readonly ILogger<ParkingPermitController> _logger;
        readonly ICOMBParkingApi _api;
        public ParkingPermitController(ICOMBParkingApi api, ILogger<ParkingPermitController> logger)
        {
            _api = api;
            _logger = logger;
        }

        List<SelectListItem> ToAspDropdownDataSource(Models.ParkingPermitsFilterModel model)
        {
            return new List<SelectListItem>
            {
                new SelectListItem("Show All Status", "", model.Expired is null),
                new SelectListItem("Expired", "true", model.Expired == true),
                new SelectListItem("Active", "false", model.Expired == false)
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] Models.ParkingPermitsFilterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestResult();

            ViewBag.CurrentFilter = model;
            ViewBag.ExpiredDropdownDataSource = ToAspDropdownDataSource(model);
            var response = await _api.ReadParkingPermitsAsync(ParkingPermitFilterFactory.Create(model));
            return response.Match<IActionResult>(
                ok => {
                    return View(ok);
                },
                ko => {
                    return View(new List<IParkingPermit>());
                });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _api.GetParkingPermitAsync(id);
            return response.Match<IActionResult>(
                ok =>
                {
                    return View(ok);
                },
                ko =>
                {
                    return NotFound();
                });
        }

        [HttpGet]
        public IActionResult ConfirmDeactivate(int id)
        {
            if (id == 0)
                return BadRequestResult();
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate([FromForm]DeactivateParkingPermitModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestResult();

            var response = await _api.DeactivateParkingPermitAsync(model.Id);
            return response.Match<IActionResult>(
                ok =>
                {
                    return RedirectToAction("Index");
                },
                ko =>
                {
                    return NotFound();
                });
        }

    }
}
