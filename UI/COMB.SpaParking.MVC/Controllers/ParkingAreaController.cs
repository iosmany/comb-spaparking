using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace COMB.SpaParking.MVC.Controllers
{
    [Authorize(Roles = Roles.CustomerServiceRep)]
    public class ParkingAreaController : BaseController
    {
        readonly Infrastructure.ICOMBParkingApi _api;
        readonly ILogger<ParkingAreaController> _logger;

        public ParkingAreaController(ILogger<ParkingAreaController> logger, Infrastructure.ICOMBParkingApi api)
        {
            _api = api;
            _logger = logger;
        }

        List<SelectListItem> ToAspDropdownDataSource(Models.ParkingAreasFilterModel model, 
            IReadOnlyCollection<IParkingAreaType> parkingAreaTypes)
        {
            var listItems= new List<SelectListItem>
            {
                new SelectListItem("Show All Status", "0", true),
            };
            parkingAreaTypes.ToList()
                .ForEach(x => listItems.Add(new SelectListItem(x.ParkingAreaTypeDescription, x.Id.ToString(), x.Id == model.ParkingAreaTypeId)));
            return listItems;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]Models.ParkingAreasFilterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestResult();

            ViewBag.CurrentFilter = model;
            var readingParkingAreaTypes = _api.ReadParkingAreaTypesAsync();
            await readingParkingAreaTypes;
            readingParkingAreaTypes.Result.Do(lst => ViewBag.ParkingAreaTypes = ToAspDropdownDataSource(model, lst));
            var response = await _api.ReadParkingAreasAsync(ParkingAreaFilterFactory.Create(model));
            return response.Match<IActionResult>(
                ok => { 
                    return View(ok);
                },
                ko => { 
                    return View(new List<IParkingArea>());
                });
        }
        
    }
}
