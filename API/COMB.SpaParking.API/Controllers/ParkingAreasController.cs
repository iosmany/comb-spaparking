using Asp.Versioning;
using COMB.SpaParking.API.Models;
using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.Application.ParkingAreas.Query;
using Microsoft.AspNetCore.Mvc;

namespace COMB.SpaParking.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiVersion(1)]
    public class ParkingAreasController : ControllerBase
    {
        readonly IGetParkingAreasListQuery _getParkingAreasListQuery;
        public ParkingAreasController(IGetParkingAreasListQuery getParkingAreasListQuery)
        {
            _getParkingAreasListQuery = getParkingAreasListQuery;
        }

        /// <summary>
        /// Get a list of parking areas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<IParkingArea>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery]ParkingAreaFilterDTO request)
        {
            var response= await _getParkingAreasListQuery.ExecuteAsync(request);
            return response.Match<IActionResult>(
                Right: entities => Ok(ApiResponse<IReadOnlyCollection<IParkingArea>>.Success(entities)),
                Left: error => BadRequest(ApiResponse<IReadOnlyCollection<IParkingArea>>.Error(error))
            );
        }
    }
}
